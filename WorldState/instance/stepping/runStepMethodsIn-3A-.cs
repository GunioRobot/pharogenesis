runStepMethodsIn: aWorld
	"Run morph 'step' methods whose time has come. Purge any morphs that are no longer in this world.
	ar 3/13/1999: Remove buggy morphs from the step list so that they don't raise repeated errors."

	| now deletions wakeupTime morphToStep |
	stepList size = 0 ifTrue: [^ self].
	now _ Time millisecondClockValue.
	((now < lastStepTime) or: [(now - lastStepTime) > 5000])
		 ifTrue: [self adjustWakeupTimes].  "clock slipped"
	deletions _ nil.
	"Note: Put the following into an error handler to prevent errors happening on stepping"
	[stepList do: [:entry |
		wakeupTime _ entry at: 2.
		morphToStep _ entry at: 1.
		morphToStep world == aWorld
			ifTrue:
				[wakeupTime <= now
					ifTrue:
						[morphToStep stepAt: now.
						entry at: 2 put: now + morphToStep stepTime]]
			ifFalse:
				[deletions ifNil: [deletions _ OrderedCollection new].
				deletions addLast: morphToStep]]]
	 ifError: [:err :rcvr |
		self stopStepping: morphToStep. "Stop this guy right now"
		morphToStep setProperty: #errorOnStep toValue: true. "Remember stepping"
		Processor activeProcess errorHandler: nil. "So we don't handle this guy twice"
		rcvr error: err. "And re-raise the error from here so the stack is still valid"].

	deletions ifNotNil:
		[deletions do: [:deletedM |
			self stopStepping: deletedM.
			deletedM stopStepping]].
	lastStepTime _ now