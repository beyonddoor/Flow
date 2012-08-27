using System;
using System.Collections.Generic;

namespace Flow
{
	/// <summary>
	/// Instances of this interface regularly fire the Elapsed event
	/// </summary>
	public interface IPeriodicTimer : IGenerator
	{
		/// <summary>
		/// Periodically occurs when the timer has elapsed.
		/// </summary>
		event TransientHandler Elapsed; 

		/// <summary>
		/// Gets the time that this periodic timer was started.
		/// </summary>
		/// <value>
		/// The time when this instance was started.
		/// </value>
		DateTime TimeStarted { get; }

		/// <summary>
		/// Gets or sets the interval. Successive Elapsed events will have not less than this TimeSpan between being fired.
		/// </summary>
		/// <value>
		/// The smallest interval between which success invocations of the Elapsed event will be fired.
		/// </value>
		TimeSpan Interval { get; set; }
	}
}