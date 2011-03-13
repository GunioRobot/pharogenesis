lowSpaceWatcher
	"Wait until the low space semaphore is signalled, then take appropriate actions."

	| free preemptedProcess |
	self garbageCollectMost <= self lowSpaceThreshold
		ifTrue: [self garbageCollect <= self lowSpaceThreshold
				ifTrue: ["free space must be above threshold before
					starting low space watcher"
					^ Beeper beep]].

	Smalltalk specialObjectsArray at: 23 put: nil.  "process causing low space will be saved here"
	LowSpaceSemaphore _ Semaphore new.
	self primLowSpaceSemaphore: LowSpaceSemaphore.
	self primSignalAtBytesLeft: self lowSpaceThreshold.  "enable low space interrupts"

	LowSpaceSemaphore wait.  "wait for a low space condition..."

	self primSignalAtBytesLeft: 0.  "disable low space interrupts"
	self primLowSpaceSemaphore: nil.
	LowSpaceProcess _ nil.

	"The process that was active at the time of the low space interrupt."
	preemptedProcess _ Smalltalk specialObjectsArray at: 23.
	Smalltalk specialObjectsArray at: 23 put: nil.

	"Note: user now unprotected until the low space watcher is re-installed"

	self memoryHogs isEmpty
		ifFalse: [free := self bytesLeft.
			self memoryHogs
				do: [ :hog | hog freeSomeSpace ].
			self bytesLeft > free
				ifTrue: [ ^ self installLowSpaceWatcher ]].
	self isMorphic
		ifTrue: [CurrentProjectRefactoring
				currentInterruptName: 'Space is low'
				preemptedProcess: preemptedProcess]
		ifFalse: [ScheduledControllers
				interruptName: 'Space is low'
				preemptedProcess: preemptedProcess]
