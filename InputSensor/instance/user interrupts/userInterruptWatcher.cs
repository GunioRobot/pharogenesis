userInterruptWatcher
	"Wait for user interrupts and open a notifier on the active process when one occurs."

	[true] whileTrue: [
		InterruptSemaphore wait.
		Display deferUpdates: false.
		SoundService default shutDown.
		Smalltalk handleUserInterrupt]
