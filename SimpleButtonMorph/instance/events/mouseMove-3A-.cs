mouseMove: evt

	(self containsPoint: evt cursorPoint)
		ifTrue: [self color: (oldColor mixed: 1/2 with: Color white).
				(actWhen == #whilePressed and: [evt anyButtonPressed])
					 ifTrue: [self doButtonAction]]
		ifFalse: [self color: oldColor].
