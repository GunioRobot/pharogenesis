lowSpaceWatcher
	"Wait until the low space semaphore is signalled, then take appropriate actions."

	| lowSpaceThreshold |
	lowSpaceThreshold _ 80000.
	self garbageCollectMost <= lowSpaceThreshold ifTrue: [
		self garbageCollect <= lowSpaceThreshold ifTrue: [
			"free space must be above threshold before starting"
			^ self beep
		].
	].

	LowSpaceSemaphore _ Semaphore new.
	self primLowSpaceSemaphore: LowSpaceSemaphore.
	self primSignalAtBytesLeft: lowSpaceThreshold.  "enable low space interrupts"

	LowSpaceSemaphore wait.  "wait for a low space condition..."

	self primSignalAtBytesLeft: 0.  "disable low space interrupts"
	self primLowSpaceSemaphore: nil.
	LowSpaceProcess _ nil.
	ScheduledControllers interruptName: 'Space is low'.
