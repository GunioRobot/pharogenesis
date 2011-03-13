nextEvent: type with: param
	"Process a single input event, aside from mouse X/Y.
	 2/8/96 sw: remove the hard-coded use of HFSMacVolume"

	| highTime lowTime |
	type = 0  "Delta time"
		ifTrue: 
			[timeProtect critical: [deltaTime _ deltaTime + param]]
		ifFalse:
			[type = 3	"Key down"
				ifTrue: [self keyAt: param put: 1]
				ifFalse:
					[type = 4	"Key up"
						ifTrue: [self keyAt: param put: 0]
						ifFalse:
							[type = 5	"Reset time"
								ifTrue:
									[InputSemaphore wait.
									highTime _ self primInputWord.
									InputSemaphore wait.
									lowTime _ self primInputWord.
									timeProtect critical:
										[baseTime _ (highTime bitShift: 16) + lowTime.
										 deltaTime _ 0]]
								ifFalse: [type = 7	"Diskette insert"
										ifTrue: ["[FileDirectory concreteFileDirectoryClass mount: param] forkAt: Processor userInterruptPriority"]
										ifFalse:
											[[Transcript show: 'Bad event type dectected in InputState nextEvent:with:'; cr] forkAt: Processor userInterruptPriority]]]]] 