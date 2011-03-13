step
	super step.
	color = onColor
		ifTrue: [super color: (onColor mixed: 0.5 with: Color black)]
		ifFalse: [super color: onColor].
