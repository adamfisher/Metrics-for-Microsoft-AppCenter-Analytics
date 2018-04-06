using System;
using System.Collections.Generic;

namespace AppCenter.Analytics.Metrics
{
    /// <summary>
    /// Represents a single App Center analytics event.
    /// </summary>
    public class AnalyticsEvent : IDisposable
    {
        #region Fields & Properties

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the event metadata properties.
        /// </summary>
        /// <value>
        /// The event metadata properties.
        /// </value>
        public IDictionary<string, string> Properties { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsEvent"/> class.
        /// </summary>
        /// <param name="name">The event name.</param>
        /// <param name="properties">The event properties.</param>
        internal AnalyticsEvent(string name, IDictionary<string, string> properties = null)
        {
            Name = name;
            Properties = properties;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
