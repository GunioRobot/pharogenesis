menuItemSelectedBorderStyleFor: aMenuItem
	"Return the selected menu item borderStyle for the given menu item."

	|c|
	c := aMenuItem owner color isTransparent
		ifTrue: [aMenuItem paneColor darker]
		ifFalse: [aMenuItem owner color darker].
	Display depth <= 2 ifTrue: [c := Color black].
	^BorderStyle raised
		width: 1;
		baseColor: c