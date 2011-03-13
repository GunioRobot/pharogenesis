menuItemInDockingBarSelectedFillStyleFor: aMenuItem
	"Answer the selected fill style to use for the given menu item that is in a docking bar."
	
	| fill baseColor preferenced |
	Display depth <= 2
		ifTrue: [^ Color gray].
	preferenced := Preferences menuSelectionColor.
	preferenced notNil ifTrue: [^preferenced].
	baseColor := aMenuItem owner color negated.
	Preferences gradientMenu
		ifFalse: [^baseColor].
	fill := GradientFillStyle ramp: {0.0 -> baseColor twiceLighter . 1 -> baseColor twiceDarker}.
	fill origin: aMenuItem topLeft.
	aMenuItem owner isVertical not
		ifTrue: [fill direction: 0 @ aMenuItem height]
		ifFalse: [fill direction: aMenuItem width @ 0].
	^ fill