﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using ME3Explorer.Unreal;
using ME3Explorer.Packages;
using NAudio.Wave;
using KFreonLib.MEDirectories;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ME3Explorer.Unreal.Classes
{
    public class WwiseStream
    {
        public byte[] memory;
        public int memsize;
        int Index;
        public SoundPlayer sp;

        public int DataSize;
        public int DataOffset;
        public int ValueOffset;
        public int Id;
        public string FileName;
        IExportEntry export;

        public bool IsPCCStored { get { return FileName == null; } }

        public WwiseStream()
        {
        }

        public WwiseStream(IExportEntry export)
        {
            this.export = export;
            Index = export.Index;
            memory = export.Data;
            memsize = memory.Length;
            Deserialize(export.FileRef);
        }

        public WwiseStream(IMEPackage pcc, int index)
        {
            Index = index;
            export = pcc.Exports[Index];
            memory = pcc.Exports[Index].Data;
            memsize = memory.Length;
            Deserialize(pcc);
        }

        public void Deserialize(IMEPackage pcc)
        {
            PropertyCollection properties = pcc.Exports[Index].GetProperties();
            //int off = pcc.Exports[Index].propsEnd() + 8;
            int off = memory.Length - 8;
            ValueOffset = off;
            DataSize = BitConverter.ToInt32(memory, off);
            DataOffset = BitConverter.ToInt32(memory, off + 4);
            NameProperty nameProp = properties.GetProp<NameProperty>("Filename");
            FileName = nameProp != null ? nameProp.Value : null;
            Id = properties.GetProp<IntProperty>("Id");
            /*for (int i = 0; i < props.Count; i++)
            {
                if (pcc.Names[props[i].Name] == "Filename")
                    FileName = pcc.Names[props[i].Value.IntValue];
                if (pcc.Names[props[i].Name] == "Id")
                    Id = props[i].Value.IntValue;
            }*/
        }

        public void ExtractToFile(string pathtoafc = "", string name = "", bool askSaveLoc = true)
        {
            if (FileName == "")
                return;
            if (FileName == null)
            {
                ExtractWav(pathtoafc, name, askSaveLoc);
            }
            else if (pathtoafc != "")
            {
                if (File.Exists(pathtoafc + FileName + ".afc"))
                    ExtractWav(pathtoafc + FileName + ".afc", name, askSaveLoc);
                else
                {
                    OpenFileDialog d = new OpenFileDialog();
                    d.Filter = FileName + ".afc|" + FileName + ".afc";
                    if (d.ShowDialog() == DialogResult.OK)
                        ExtractWav(d.FileName, name, askSaveLoc);
                }
            }
            else
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = FileName + ".afc|" + FileName + ".afc";
                if (d.ShowDialog() == DialogResult.OK)
                    ExtractWav(d.FileName, name, askSaveLoc);
            }
        }

        public void ImportFromFile(string path, string pathtoafc = "")
        {
            if (FileName == "")
                return;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (pathtoafc != "")
                {
                    if (File.Exists(pathtoafc))
                        ImportWwiseOgg(pathtoafc, stream, DataOffset);
                    else if (File.Exists(pathtoafc + FileName + ".afc")) //legacy code for old soundplorer
                        ImportWwiseOgg(pathtoafc + FileName + ".afc", stream, DataOffset);
                    else
                    {
                        OpenFileDialog d = new OpenFileDialog();
                        d.Filter = FileName + ".afc|" + FileName + ".afc";
                        if (d.ShowDialog() == DialogResult.OK)
                            ImportWwiseOgg(d.FileName, stream, DataOffset);
                    }
                }
                else
                {
                    OpenFileDialog d = new OpenFileDialog();
                    d.Filter = FileName + ".afc|" + FileName + ".afc";
                    if (d.ShowDialog() == DialogResult.OK)
                        ImportWwiseOgg(d.FileName, stream, DataOffset);
                }
            }
        }

        public Stream GetPCMStream(string path)
        {
            return CreateWaveStream(path);
            string wavPath = CreateWave(path);
            if (wavPath != null && File.Exists(wavPath))
            {
                byte[] pcmBytes = File.ReadAllBytes(wavPath);
                File.Delete(wavPath);
                return new MemoryStream(pcmBytes);
            }
            return null;
        }

        public void Play(string afcPath = "")
        {
            if (FileName == "")
                return;
            if (FileName == null)
            {
                PlayWave(afcPath);
            }
            else if (afcPath != "")
            {
                if (File.Exists(afcPath + FileName + ".afc"))
                    PlayWave(afcPath + FileName + ".afc");
                else
                {
                    OpenFileDialog d = new OpenFileDialog();
                    d.Filter = FileName + ".afc|" + FileName + ".afc";
                    if (d.ShowDialog() == DialogResult.OK)
                        PlayWave(d.FileName);
                }
            }
            else
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = FileName + ".afc|" + FileName + ".afc";
                if (d.ShowDialog() == DialogResult.OK)
                    PlayWave(d.FileName);
            }
        }

        public TimeSpan? GetSoundLength()
        {
            string path;
            if (IsPCCStored)
            {
                path = export.FileRef.FileName;
            }
            else
            {
                path = getPathToAFC();
            }

            Stream waveStream = CreateWaveStream(path);
            if (waveStream != null)
            {
                //Check it is RIFF
                byte[] riffHeaderBytes = new byte[4];
                waveStream.Read(riffHeaderBytes, 0, 4);
                string wemHeader = "" + (char)riffHeaderBytes[0] + (char)riffHeaderBytes[1] + (char)riffHeaderBytes[2] + (char)riffHeaderBytes[3];
                if (wemHeader == "RIFF")
                {
                    waveStream.Position = 0;
                    WaveFileReader wf = new WaveFileReader(waveStream);
                    return wf.TotalTime;
                }
            }
            return null;
        }

        public string getPathToAFC()
        {
            //Check if pcc-stored
            if (export.FileRef.FileName == "")
            {

            }

            //Look in currect directory first


            string path = Path.Combine(Path.GetDirectoryName(export.FileRef.FileName), FileName + ".afc");
            if (File.Exists(path))
            {
                return path; //in current directory of this pcc file
            }

            switch (export.FileRef.Game)
            {
                case MEGame.ME2:
                    path = ME2Directory.cookedPath;
                    break;
                case MEGame.ME3:
                    path = ME3Directory.cookedPath;
                    break;
            }
            path += FileName + ".afc";

            if (File.Exists(path))
            {
                return path; //in main CookedPCConsoleDirectory
            }

            //Todo: Look in DLC directories, though this might be pretty slow if DLC is all unpacked.

            //Todo: Figure out how to do this on UI thread as this method will be called from both UI and non-UI threads.
            /*
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = w.FileName + ".afc|" + w.FileName + ".afc";
                if (d.ShowDialog().Value)
                {
                    afcPath = System.IO.Path.GetDirectoryName(d.FileName) + '\\';
                }
                else
                {
                    return "";
                }
            }*/
            return "";
        }

        /// <summary>
        /// Creates wav file in temp directory
        /// </summary>
        /// <param name="afcPath"></param>
        /// <returns></returns>
        public string CreateWave(string afcPath)
        {
            string basePath = System.IO.Path.GetTempPath() + "ME3EXP_SOUND_" + Guid.NewGuid().ToString();
            if (ExtractRawFromStream(basePath + ".dat", getPathToAFC()))
            {
                ConvertRiffToWav(basePath + ".dat", export.FileRef.Game == MEGame.ME2);
            }
            return basePath + ".wav";
        }


        /// <summary>
        /// Creates wav stream from this WwiseStream
        /// </summary>
        /// <param name="afcPath"></param>
        /// <returns></returns>
        public Stream CreateWaveStream(string afcPath)
        {
            string basePath = System.IO.Path.GetTempPath() + "ME3EXP_SOUND_" + Guid.NewGuid().ToString();
            if (ExtractRawFromStream(basePath + ".dat", getPathToAFC()))
            {
                return ConvertRiffToWav(basePath + ".dat", export.FileRef.Game == MEGame.ME2);
            }
            return null;
        }
        private void PlayWave(string path)
        {
            string wavPath = CreateWave(path);
            if (wavPath != null && File.Exists(wavPath))
            {
                sp = new SoundPlayer(wavPath);
                sp.Play();
                while (!sp.IsLoadCompleted)
                    Application.DoEvents();
            }
        }

        private void ExtractWav(string path, string name = "", bool askSave = true)
        {
            string wavPath = CreateWave(path);
            if (wavPath != null && File.Exists(wavPath))
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Wave Files(*.wav)|*.wav";
                d.FileName = name + ".wav";
                if (askSave)
                {
                    if (d.ShowDialog() == DialogResult.OK)
                        File.Copy(wavPath, d.FileName);
                }
                else
                {
                    File.Copy(wavPath, name, true);
                }
                if (askSave)
                    MessageBox.Show("Done.");
            }
        }

        /// <summary>
        /// Converts a RAW RIFF from game data to a playable WAV stream. This can be written to disk as a playable WAV file.
        /// </summary>
        /// <param name="riffPath">Path to RIFF RAW data</param>
        /// <param name="fullSetup">Full setup flag - use for ME2</param>
        public static MemoryStream ConvertRiffToWav(string riffPath, bool fullSetup)
        {
            Stream oggStream = ConvertRIFFToWWwiseOGG(riffPath, fullSetup);
            if (oggStream != null)// && File.Exists(outputOggPath))
            {
                oggStream.Seek(0, SeekOrigin.Begin);
                string oggPath = Path.Combine(Directory.GetParent(riffPath).FullName, Path.GetFileNameWithoutExtension(riffPath)) + ".ogg";

                using (FileStream fs = new FileStream(oggPath, FileMode.OpenOrCreate))
                {
                    oggStream.CopyTo(fs);
                    fs.Flush();
                }

                //convert OGG to WAV
                string loc = Path.GetDirectoryName(Application.ExecutablePath) + "\\exec";
                MemoryStream outputData = new MemoryStream();

                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo(loc + "\\oggdec.exe", "--stdout " + oggPath);
                procStartInfo.WorkingDirectory = loc;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                //procStartInfo.StandardOutputEncoding = Encoding.GetEncoding(850); //standard cmd-page
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;

                // Set our event handler to asynchronously read the sort output.
                proc.Start();
                //proc.BeginOutputReadLine();
                var outputTask = Task.Run(() =>
                {
                    proc.StandardOutput.BaseStream.CopyTo(outputData);

                    /*using (var output = new FileStream(outputFile, FileMode.Create))
                    {
                        process.StandardOutput.BaseStream.CopyTo(output);
                    }*/
                });
                Task.WaitAll(outputTask);

                proc.WaitForExit();
                File.Delete(riffPath); //raw
                File.Delete(oggPath); //intermediate

                //Fix headers as they are not correct when output from oggdec over stdout - no idea what it is outputting.
                outputData.Position = 0x4;
                outputData.Write(BitConverter.GetBytes(((int)outputData.Length) - 0x8), 0, 4); //filesize
                outputData.Position = 0x28;
                outputData.Write(BitConverter.GetBytes(((int)outputData.Length) - 0x24), 0, 4); //datasize
                outputData.Position = 0;
                return outputData;
            }
            return null;
        }

        /// <summary>
        /// Converts a RAW RIFF from game data to a Wwise-based Ogg Vorbis stream
        /// </summary>
        /// <param name="riffPath">Path to RIFF RAW data</param>
        /// <param name="fullSetup">Full setup flag - use for ME2</param>
        public static MemoryStream ConvertRIFFToWWwiseOGG(string riffPath, bool fullSetup)
        {
            //convert RIFF to WwiseOGG
            //System.Diagnostics.Debug.WriteLine("ww2ogg: " + riffPath);
            if (!File.Exists(riffPath))
            {
                System.Diagnostics.Debug.WriteLine("Error: input file does not exist");
            }
            string loc = Path.GetDirectoryName(Application.ExecutablePath) + "\\exec";
            System.Diagnostics.ProcessStartInfo procStartInfo = null;
            if (!fullSetup)
            {
                procStartInfo = new System.Diagnostics.ProcessStartInfo(loc + "\\ww2ogg.exe", "--stdout \"" + riffPath + "\"");
            }
            else
            {
                procStartInfo = new System.Diagnostics.ProcessStartInfo(loc + "\\ww2ogg.exe", "--stdout --full-setup \"" + riffPath + "\"");
            }
            procStartInfo.WorkingDirectory = loc;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;

            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();

            MemoryStream outputData = new MemoryStream();
            var outputTask = Task.Run(() =>
            {
                proc.StandardOutput.BaseStream.CopyTo(outputData);

                /*using (var output = new FileStream(outputFile, FileMode.Create))
                {
                    process.StandardOutput.BaseStream.CopyTo(output);
                }*/
            });
            Task.WaitAll(outputTask);

            proc.WaitForExit();
            proc.Close();

            //Debug.WriteLine("Done");
            return outputData;
            //            return Path.Combine(Directory.GetParent(riffPath).FullName, Path.GetFileNameWithoutExtension(riffPath)) + ".ogg";
        }

        public bool ExtractRawFromStream(string outputFile, string afcPath)
        {
            if (!File.Exists(afcPath))
                return false;

            Stream embeddedStream = null;
            if (afcPath.EndsWith(".pcc"))
            {
                using (IMEPackage package = MEPackageHandler.OpenMEPackage(afcPath))
                {
                    if (package.IsCompressed)
                    {
                        embeddedStream = new MemoryStream(CompressionHelper.Decompress(afcPath));
                    }
                }
            }

            using (Stream fs = embeddedStream != null ? embeddedStream : new FileStream(afcPath, FileMode.Open, FileAccess.Read))
            {
                if (DataOffset + DataSize > fs.Length)
                    return false;

                if (File.Exists(outputFile))
                    File.Delete(outputFile);
                using (FileStream fs2 = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    fs.Seek(DataOffset, SeekOrigin.Begin);
                    //for (int i = 0; i < DataSize; i++)
                    //    fs2.WriteByte((byte)fs.ReadByte());
                    byte[] dataToCopy = new byte[DataSize];
                    fs.Read(dataToCopy, 0, DataSize);
                    fs2.Write(dataToCopy, 0, DataSize);
                }
            }
            return true;
        }

        private MemoryStream ExtractRiffFromStream(Stream fs)
        {
            MemoryStream fs2 = new MemoryStream();
            fs.Seek(DataOffset, SeekOrigin.Begin);
            for (int i = 0; i < DataSize; i++)
                fs2.WriteByte((byte)fs.ReadByte());
            fs.Close();
            return fs2;
        }

        /// <summary>
        /// Converts a Wwise-genreated ogg to the format usable by ME3.
        /// This effectivey replaces the need for afc_creator.exe
        /// </summary>
        /// <param name="memory">Stream containing wwiseogg</param>
        /// <returns>ME3 AFC ready stream, at position 0</returns>
        private MemoryStream ConvertWwiseOggToME3Ogg(Stream memory)
        {
            memory.Position = 0;
            MemoryStream convertedStream = new MemoryStream();
            memory.CopyToEx(convertedStream, 4);
            convertedStream.Write(BitConverter.GetBytes((int)memory.Length - 16), 0, 4);
            memory.Position += 4; //skip over size
            memory.CopyToEx(convertedStream, 0x24); //up to VORB
            memory.Position += 8; //skip vorb
            memory.CopyTo(convertedStream); //copy remaining data

            //update format bytes
            convertedStream.Seek(0x10, SeekOrigin.Begin);
            byte[] firstFmtBytes = { 0x42, 0x00, 0x00, 0x00, 0xFF, 0xFF };
            convertedStream.Write(firstFmtBytes, 0x0, firstFmtBytes.Length);

            //Update second format bytes
            convertedStream.Seek(0x20, SeekOrigin.Begin);
            byte[] secondFmtBytes = { 0x00, 0x00, 0x00, 0x00, 0x30, 0x00, 0x18, 0x00 };
            convertedStream.Write(secondFmtBytes, 0x0, secondFmtBytes.Length);

            convertedStream.Position = 0;
            return convertedStream;
        }

        private void ImportWwiseOgg(string pathafc, Stream wwiseOggStream, int off)
        {
            if (!File.Exists(pathafc) || wwiseOggStream == null)
                return;
            //Convert wwiseoggstream
            MemoryStream convertedStream = ConvertWwiseOggToME3Ogg(wwiseOggStream);
            //Open AFC
            FileStream fs = new FileStream(pathafc, FileMode.Open, FileAccess.Read);
            byte[] Header = new byte[94];

            //Seek to data we are replacing and read header
            fs.Seek(DataOffset, SeekOrigin.Begin);
            fs.Read(Header, 0, 94);

            //for (int i = 0; i < 94; i++)
            //    Header[i] = (byte)fs.Read();
            fs.Close();

            //read wave file into memory
            //fs = new FileStream(pathwav, FileMode.Open, FileAccess.Read);
            MemoryStream tempStream = new MemoryStream();
            byte[] newWavfile = convertedStream.ToArray();
            /*byte[] newfile = new byte[fs.Length];
            for (int i = 0; i < fs.Length; i++)
                newfile[i] = (byte)fs.ReadByte();
            fs.Close();*/

            //tweak new wav header
            //newWavfile = ModifyHeader(newWavfile, Header);

            //append new wav
            fs = new FileStream(pathafc, FileMode.Append, FileAccess.Write, FileShare.Write);
            int newWavDataOffset = (int)fs.Length;
            int newWavSize = newWavfile.Length;
            fs.Write(newWavfile, 0, newWavSize);
            //for (int i = 0; i < newWavSize; i++)
            //    fs.WriteByte(newWavfile[i]);
            //uint newafcsize = (uint)fs.Length;
            fs.Close();

            //update memory in this export (clone of memory)
            byte[] buff = BitConverter.GetBytes(newWavSize);
            for (int i = 0; i < 4; i++)
                memory[ValueOffset + i - 4] = buff[i];
            for (int i = 0; i < 4; i++)
                memory[ValueOffset + i] = buff[i];
            buff = BitConverter.GetBytes(newWavDataOffset);
            for (int i = 0; i < 4; i++)
                memory[ValueOffset + i + 4] = buff[i];
            DataSize = newWavSize;
            DataOffset = newWavDataOffset;
        }

        /// <summary>
        /// Not gonna lie, I have no idea what this does, but I also didn't write it.
        /// - Mgamerz
        /// </summary>
        /// <param name="nw"></param>
        /// <param name="old"></param>
        /// <returns></returns>
        private byte[] ModifyHeader(byte[] nw, byte[] old)
        {
            MemoryStream m = new MemoryStream();
            m.Write(nw, 0, 8);
            m.Write(old, 8, 14);
            m.Write(nw, 22, 10);
            m.Write(old, 32, 8);
            m.Write(nw, 40, 4);
            int len = nw.Length - 52;
            m.Write(nw, 52, len);
            return m.ToArray();
        }
    }
}
