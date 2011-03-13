userInterruptWatcher
	"Wait for user interrupts and open a notifier on the active process when one occurs."

	[true] whileTrue: [
		InterruptSemaphore wait.
		SoundPlayer shutDown.
		[ScheduledControllers interruptName: 'User Interrupt'] fork.
	].
