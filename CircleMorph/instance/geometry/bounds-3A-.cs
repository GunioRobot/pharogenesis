bounds: aRectangle
	| size |
	size _ aRectangle width min: aRectangle height.
	super bounds: (Rectangle origin: aRectangle origin extent: size @ size).