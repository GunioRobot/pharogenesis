step
	| evt |
	evt _ hand lastEvent.
	evt anyButtonPressed
		ifTrue: [waitingForClickInside _ false.
				self position: evt cursorPoint - (self extent // 2).
				pointBlock value: self center]
		ifFalse: [waitingForClickInside
					ifTrue: [(self containsPoint: evt cursorPoint)
								ifFalse: ["mouse wandered out before clicked"
										^ self delete]]
					ifFalse: [lastPointBlock value: self center.
							^ self delete]]