fillOval: r color: c borderWidth: borderWidth borderColor: borderColor

	| rect fillC borderC |
	rect _ r.
	c isTransparent
		ifTrue: [fillC _ nil]
		ifFalse: [fillC _ self drawColor: c].
	borderColor isTransparent
		ifTrue: [
			fillC == nil ifTrue: [^ self].  "both border and fill are transparent"
			borderC _ nil.
			rect _ rect insetBy: borderWidth]
		ifFalse: [borderC _ self drawColor: borderColor].

	port combinationRule: (self drawRule: Form over).
	port fillOval: (rect translateBy: origin)
		color: fillC
		borderWidth: borderWidth
		borderColor: borderC.
