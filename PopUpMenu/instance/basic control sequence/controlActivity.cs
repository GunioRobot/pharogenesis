controlActivity
	"Do whatever a menu must do - now with keyboard support."

	| didNotMove downPos |
	didNotMove _ true.
	Sensor anyButtonPressed
		ifFalse:
			[didNotMove _ false.
			Sensor waitButtonOrKeyboard]. 
	
	Sensor keyboardPressed ifFalse: [self manageMarker].
	(didNotMove and: [selection = 0])
		ifTrue:
			[downPos _ Sensor cursorPoint.
			[didNotMove and: [Sensor anyButtonPressed]]
				whileTrue:
					[(downPos dist: Sensor cursorPoint) < 2 ifFalse: [didNotMove _ false]].
			didNotMove ifTrue: [Sensor waitButtonOrKeyboard]].

	[Sensor keyboardPressed] whileTrue:
		[self readKeyboard ifTrue: [^ self].
		Sensor waitButtonOrKeyboard].

	[Sensor anyButtonPressed] whileTrue: [self manageMarker]