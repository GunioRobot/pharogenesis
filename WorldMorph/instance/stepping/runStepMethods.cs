runStepMethods
	"Run morph 'step' methods whose time has come. Purge any morphs that are no longer in this world."

	| now deletions wakeupTime m |
	stepList size = 0 ifTrue: [^ self].
	now _ Time millisecondClockValue.
	((now < lastStepTime) or: [(now - lastStepTime) > 5000])
		 ifTrue: [self adjustWakeupTimes].  "clock slipped"
	deletions _ OrderedCollection new.
	stepList do: [:entry |
		wakeupTime _ entry at: 2.
		m _ entry at: 1.
		m world == self
			ifTrue: [
				wakeupTime <= now
					ifTrue: [
						m step.
						entry at: 2 put: now + m stepTime]]
			ifFalse: [deletions addLast: m]].
	deletions do: [:goner |
		self stopStepping: goner.
		goner stopStepping].
	lastStepTime _ now.
