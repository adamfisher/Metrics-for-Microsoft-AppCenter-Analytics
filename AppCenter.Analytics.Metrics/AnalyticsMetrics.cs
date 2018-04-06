using System.Collections.Generic;
using Microsoft.AppCenter;

namespace AppCenter.Analytics.Metrics
{
    /// <summary>
    /// Provides additional metrics for Microsoft App Center analytics.
    /// </summary>
    /// <seealso cref="IAppCenterService" />
    public class AnalyticsMetrics : IAppCenterService
    { 
        #region General

        /// <summary>
        /// Tracks an analytics event.
        /// </summary>
        /// <param name="analyticsEvent">The analytics event.</param>
        internal static void TrackEvent(AnalyticsEvent analyticsEvent)
        {
            if (analyticsEvent != null)
            {
                Microsoft.AppCenter.Analytics.Analytics.TrackEvent(analyticsEvent.Name, analyticsEvent.Properties);
            }
        }

        /// <summary>
        /// Tracks an analytics event.
        /// </summary>
        /// <param name="name">The name of the event.</param>
        /// <param name="propertyKey">An event metadata property key.</param>
        /// <param name="propertyValue">An event metadata property value.</param>
        internal static void TrackEvent(string name, string propertyKey, string propertyValue)
        {
            Microsoft.AppCenter.Analytics.Analytics.TrackEvent(name, new Dictionary<string, string>() { { propertyKey, propertyValue } });
        }

        #endregion

        #region AnalyticsTimedEvent

        /// <summary>
        /// Measures how long an operation took to complete. 
        /// The <code>AnalyticsTimedEvent</code> implements the IDisposable pattern and is typically used inside of a using block.
        /// When the object is created, the start time is automatically set.
        /// Whent he object is disposed, the end time is automatically set and the event is sent to App Center.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="eventProperties">The event properties.</param>
        /// <returns>An analytics object capable of tracking a single event.</returns>
        public static AnalyticsTimedEvent TrackTimedEvent(string eventName, IDictionary<string, string> eventProperties = null)
        {
            return new AnalyticsTimedEvent(eventName, eventProperties);
        }

        /// <summary>
        /// Measures how long an operation took to complete.
        /// The <code>AnalyticsTimedEvent</code> implements the IDisposable pattern and is typically used inside of a using block.
        /// When the object is created, the start time is automatically set.
        /// Whent he object is disposed, the end time is automatically set and the event is sent to App Center.
        /// </summary>
        /// <param name="analyticsTimedEvent">The analytics timed event.</param>
        public static void TrackTimedEvent(AnalyticsTimedEvent analyticsTimedEvent)
        {
            analyticsTimedEvent?.Dispose();
        }

        #endregion
    }
}
