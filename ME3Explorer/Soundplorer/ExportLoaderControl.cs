﻿using ME3Explorer.Packages;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ME3Explorer
{
    /// <summary>
    /// Subclass of UserControl that also sets up the CurrentLoadedExport, LoadExport(), UnloadExport() and more methods
    /// </summary>
    public abstract class ExportLoaderControl : UserControl
    {
        public abstract bool CanParse(IExportEntry exportEntry);
        public static MEGame[] SupportedGames;
        private IExportEntry _currentLoadedExport;
        public IExportEntry CurrentLoadedExport
        {
            get
            {
                return _currentLoadedExport;
            }
            protected set
            {
                SetProperty(ref _currentLoadedExport, value);
            }
        }

        public abstract void LoadExport(IExportEntry exportEntry);
        public abstract void UnloadExport();


        #region Property Changed Notification
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners when given property is updated.
        /// </summary>
        /// <param name="propertyname">Name of property to give notification for. If called in property, argument can be ignored as it will be default.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        /// <summary>
        /// Sets given property and notifies listeners of its change. IGNORES setting the property to same value.
        /// Should be called in property setters.
        /// </summary>
        /// <typeparam name="T">Type of given property.</typeparam>
        /// <param name="field">Backing field to update.</param>
        /// <param name="value">New value of property.</param>
        /// <param name="propertyName">Name of property.</param>
        /// <returns>True if success, false if backing field and new value aren't compatible.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}