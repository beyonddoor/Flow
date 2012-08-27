// (C) 2012 christian.schladetsch@gmail.com

using System;

namespace Flow
{
	/// <summary>
	/// Generator handler.
	/// </summary>
	public delegate void GeneratorHandler(IGenerator generator);

	/// <summary>
	/// An instance of IGenerator does some work every time it's Step() method is called, unless it is Suspended or Deleted.
	/// </summary>
	public interface IGenerator : ITransient
	{
		/// <summary>
		/// Occurs when suspended.
		/// </summary>
		event GeneratorHandler Suspended;
        
		/// <summary>
		/// Occurs when resumed.
		/// </summary>
        event GeneratorHandler Resumed;

		/// <summary>
		/// Gets a value indicating whether this <see cref="Flow.IGenerator"/> is running.
		/// </summary>
		/// <value>
		/// <c>true</c> if running; otherwise, <c>false</c>.
		/// </value>
        bool Running { get; }

		/// <summary>
		/// Gets the step number.
		/// </summary>
		/// <value>
		/// The step number.
		/// </value>
		int StepNumber { get; }

		/// <summary>
		/// Resume this instance.
		/// </summary>
        void Resume();

		/// <summary>
		/// Step this instance. TODO: return type should be void.
		/// </summary>
        bool Step();

		/// <summary>
		/// Called in a Step of the Kernel after all other generators have been Step'd by the Kernel.
		/// </summary>
		void Stepped();

		/// <summary>
		/// Suspend this instance. After this, Step() does nothing.
		/// </summary>
        void Suspend();
        
		/// <summary>
		/// Suspends this instance after another transient has been deleted
		/// </summary>
		/// <param name='transient'>
		/// When the given transient is deleted, this instance will be suspended
		/// </param>
        void SuspendAfter(ITransient transient);
        
		/// <summary>
		/// Resumes this instance after another transient has been deleted.
		/// </summary>
		/// <returns>
		/// True if the given transient exists.
		/// </returns>
		/// <param name='transient'>
		/// When the given transient is deleted, this instance will be resumed.
		/// </param>
        bool ResumeAfter(ITransient transient);

		
		bool ResumeAfter(TimeSpan span);

		bool SuspendAfter(TimeSpan span);
	}
}