keyAt: index put: value

	| mask |
	index < 8r200
	  ifTrue:  "Not a potential special character"
		[value ~= 0 ifTrue:
			[(index = $. asciiValue and: [ctrlState ~= 0])
				ifTrue: [[ScheduledControllers interruptName: 'User Interrupt'] fork. ^self].
			"(index = $z asciiValue and: [ctrlState ~= 0])
				ifTrue: [ScheduledControllers scheduleFromKeyPress: ScheduledControllers bottomController.
						^ self].
			(index = $a asciiValue and: [ctrlState ~= 0])
				ifTrue: [ScheduledControllers scheduleFromKeyPress: ScheduledControllers penultimateController.
						^ self]."
			^keyboardQueue nextPut: (KeyboardEvent code: index meta: metaState)]]
	  ifFalse:
		[index = CtrlKey
		  ifTrue: [ctrlState _ value bitShift: 1]
		  ifFalse:
			[index = LshiftKey
			  ifTrue: [lshiftState _ value]
			  ifFalse:
				[index = RshiftKey
				  ifTrue: [rshiftState _ value]
				  ifFalse:
					[index = LockKey
					  ifTrue: [lockState _ value bitShift: 2]
					  ifFalse:
						[(index >= BitMin and: [index <= BitMax])
						  ifTrue:
							[mask _ 1 bitShift: index - BitMin.
							self bitState: mask incoming: value]
						  ifFalse:
							[value ~= 0 ifTrue:
								[keyboardQueue nextPut:
									(KeyboardEvent code: index meta: metaState)]]]]]].
		metaState _ (ctrlState bitOr: (lshiftState bitOr: rshiftState)) bitOr: lockState]