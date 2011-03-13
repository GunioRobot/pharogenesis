example
	"This simple example illustrates how to display a few lines of text on the screen at the current cursor point. "

	| para point |
	point _ Sensor waitButton.
	para _ 'This is the first line of characters
and this is the second line.' asParagraph.
	para displayOn: Display at: point.
	para
		displayOn: Display
		at: point + (0 @ para height)
		clippingBox: (point + (0 @ para height) extent: para extent)
		rule: Form over
		fillColor: Color gray

	"Paragraph example"