mouseMove: evt

	(self containsPoint: evt cursorPoint)
		ifTrue: [self state: #pressed.
				actWhen == #whilePressed ifTrue: [self doButtonAction]]
		ifFalse: [self state: #off].
