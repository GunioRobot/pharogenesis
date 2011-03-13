layoutBounds
	"Return the bounds for laying out children of the receiver"
	| inset box |
	inset _ self layoutInset.
	box _ self innerBounds.
	inset isZero ifTrue:[^box].
	^box insetBy: inset.