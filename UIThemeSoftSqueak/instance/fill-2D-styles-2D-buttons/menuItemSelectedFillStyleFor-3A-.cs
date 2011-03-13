menuItemSelectedFillStyleFor: aMenuItem
	"Answer the selected fill style to use for the given menu item."
	
	|c|
	Display depth <= 2 ifTrue: [^ Color gray].
	c := aMenuItem owner color isTransparent
		ifTrue: [aMenuItem paneColor darker]
		ifFalse: [aMenuItem owner color darker].
	^(GradientFillStyle ramp: {
			0.0->Color white.
			0.2->c twiceLighter.
			0.8->c darker.
			1.0->c darker duller})
		origin: aMenuItem topLeft;
		direction: 0 @ aMenuItem height