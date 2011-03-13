selectionFillStyle
	"answer the fill style to use with the receiver is the selected  
	element"
	| fill baseColor preferenced |
	Display depth <= 2
		ifTrue: [^ Color gray].

	preferenced := Preferences menuSelectionColor.
	preferenced notNil ifTrue:[^ preferenced].

	baseColor := owner color negated.
	Preferences gradientMenu
		ifFalse: [^ baseColor].
	fill := GradientFillStyle ramp: {0.0 -> baseColor twiceLighter . 1 -> baseColor twiceDarker}.
	fill origin: self topLeft.
	(self isInDockingBar
			and: [self owner isVertical not])
		ifTrue: [fill direction: 0 @ self height]
		ifFalse: [fill direction: self width @ 0].
	^ fill