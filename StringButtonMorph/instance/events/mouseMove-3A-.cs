mouseMove: evt
	actWhen == #buttonDown ifTrue: [^ self].
	(self containsPoint: evt cursorPoint)
		ifTrue:
			[self color: (oldColor mixed: 1/2 with: Color white).
			actWhen == #whilePressed ifTrue: [self doButtonAction]]
		ifFalse: [self color: oldColor].
