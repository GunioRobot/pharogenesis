runLocalStepMethodsIn: aWorld
	"Run morph 'step' methods (LOCAL TO THIS WORLD) whose time has come. Purge any morphs that are no longer in this world.
	ar 3/13/1999: Remove buggy morphs from the step list so that they don't raise repeated errors."

	| now morphToStep stepTime |
	now _ Time millisecondClockValue.
	self triggerAlarmsBefore: now.
	stepList size = 0 ifTrue: [^ self].
	((now < lastStepTime) or: [(now - lastStepTime) > 5000])
		 ifTrue: [self adjustWakeupTimes: now].  "clock slipped"
	[stepList isEmpty not and:[stepList first scheduledTime < now]] whileTrue:[
		lastStepMessage _ stepList removeFirst.
		morphToStep _ lastStepMessage receiver.
		(morphToStep shouldGetStepsFrom: aWorld) ifTrue:[
			lastStepMessage value: now.
			lastStepMessage ifNotNil:[
				stepTime _ lastStepMessage stepTime ifNil:[morphToStep stepTime].
				lastStepMessage scheduledTime: now + (stepTime max: 1).
				stepList add: lastStepMessage].
		].
		lastStepMessage _ nil.
	].
	lastStepTime _ now