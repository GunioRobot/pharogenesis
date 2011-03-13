example
	"This simple example illustrates how to display a few lines of text on the screen at the current cursor point.  
	Fixed. "

	| para point |
	point := Sensor waitButton.
	para := 'This is the first line of characters
and this is the second line.' asParagraph.
	para displayOn: Display at: point.

	"Paragraph example"