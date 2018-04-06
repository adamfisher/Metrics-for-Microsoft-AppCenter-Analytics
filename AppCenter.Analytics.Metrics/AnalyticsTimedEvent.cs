using System;
using System.Collections.Generic;

namespace AppCenter.Analytics.Metrics
{
    /// <summary>
    /// Represent an event with time duration information.
    /// </summary>
    /// <seealso cref="AnalyticsEvent" />
    public class AnalyticsTimedEvent : AnalyticsEvent
    {
        #region Fields & Properties

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The event start time.
        /// </value>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The event end time.
        /// </value>
        public DateTime? EndTime { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsTimedEvent"/> class.
        /// </summary>
        /// <param name="name">The event name.</param>
        /// <param name="properties">The event properties.</param>
        public AnalyticsTimedEvent(string name, IDictionary<string, string> properties = null) : base(name, properties)
        {
            StartTime = DateTime.Now;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                StartTime = StartTime ?? DateTime.Now;
                EndTime = EndTime ?? DateTime.Now;

                if (Properties == null)
                {
                    Properties = new Dictionary<string, string>(3);
                }

                Properties.Add("Start Time", StartTime.ToString());
                Properties.Add("End Time", EndTime.ToString());
                Properties.Add("Duration", EndTime.Value.Subtract(StartTime.Value).ToString());

                Microsoft.AppCenter.Analytics.Analytics.TrackEvent(Name, Properties);
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
