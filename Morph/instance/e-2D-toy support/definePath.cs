definePath
	| points lastPoint aForm offset currentPoint dwell ownerPosition |
	points _ OrderedCollection new: 70.
	lastPoint _ nil.
	aForm _ self imageForm.
	offset _ aForm extent // 2.
	ownerPosition _ owner position.
	Cursor move show.
	Sensor waitButton.
	[Sensor anyButtonPressed and: [points size < 100]] whileTrue:
		[currentPoint _ Sensor cursorPoint.
		dwell _ 0.
		currentPoint = lastPoint
			ifTrue:
				[dwell _ dwell + 1.
				((dwell \\ 1000) = 0) ifTrue:
					[Beeper beep]]
			ifFalse:
				[self position: (currentPoint - offset).
				self world displayWorld.
				(Delay forMilliseconds: 20) wait.
				points add: currentPoint.
				lastPoint _ currentPoint]].
	points size > 1
		ifFalse:
			[self inform: 'no path obtained']
		ifTrue:
			[points size = 100 ifTrue: [self playSoundNamed: 'croak'].

			Transcript cr; show: 'path defined with
', points size printString, ' points'.
			self renderedMorph setProperty: #pathPoints toValue: 
				(points collect: [:p | p - ownerPosition])].

	Cursor normal show
		