menuItemSelectedFillStyleFor: aMenuItem
	"Answer the selected fill style to use for the given menu item."
	
	| fill baseColor preferenced |
	Display depth <= 2
		ifTrue: [^ Color gray].
	preferenced := Preferences menuSelectionColor.
	preferenced notNil ifTrue: [^preferenced].
	baseColor := aMenuItem owner color negated.
	Preferences gradientMenu
		ifFalse: [^baseColor].
	fill := GradientFillStyle ramp: {0.0 -> baseColor twiceLighter . 1 -> baseColor twiceDarker}.
	fill
		origin: aMenuItem topLeft;
		direction: aMenuItem width @ 0.
	^ fill