mouseMove: evt
	actWhen == #buttonDown ifTrue: [^ self].
	(self containsPoint: evt cursorPoint)
		ifTrue: [oldColor ifNotNil: [self color: (oldColor mixed: 1/2 with: Color white)].
				(actWhen == #whilePressed and: [evt anyButtonPressed])
					 ifTrue: [self doButtonAction.
							evt hand noteSignificantEvent: evt]]
		ifFalse: [oldColor ifNotNil: [self color: oldColor]].
