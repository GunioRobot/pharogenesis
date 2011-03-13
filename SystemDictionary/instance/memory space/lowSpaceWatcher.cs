lowSpaceWatcher
	"Wait until the low space semaphore is signalled, then take appropriate actions."

	| free |
	self garbageCollectMost <= self lowSpaceThreshold ifTrue: [
		self garbageCollect <= self lowSpaceThreshold ifTrue: [
			"free space must be above threshold before starting low space watcher"
			^ self beep]].

	LowSpaceSemaphore _ Semaphore new.
	self primLowSpaceSemaphore: LowSpaceSemaphore.
	self primSignalAtBytesLeft: self lowSpaceThreshold.  "enable low space interrupts"

	LowSpaceSemaphore wait.  "wait for a low space condition..."

	self primSignalAtBytesLeft: 0.  "disable low space interrupts"
	self primLowSpaceSemaphore: nil.
	LowSpaceProcess _ nil.
	"Note: user now unprotected until the low space watcher is re-installed"

	self memoryHogs isEmpty ifFalse: [
		free := self bytesLeft.
		self memoryHogs do: [ :hog | hog freeSomeSpace ].
		self bytesLeft > free ifTrue: [ ^ self installLowSpaceWatcher ]].

	Smalltalk isMorphic
			ifTrue: [CurrentProjectRefactoring currentInterruptName: 'Space is low']
			ifFalse: [ScheduledControllers interruptName: 'Space is low']