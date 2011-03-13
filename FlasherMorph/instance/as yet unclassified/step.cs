step
	super step.
	color = onColor
		ifTrue: [super color: (onColor alphaMixed: 0.5 with: Color black)]
		ifFalse: [super color: onColor].
