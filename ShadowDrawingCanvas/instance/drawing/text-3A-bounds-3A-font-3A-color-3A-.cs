text: s bounds: boundsRect font: fontOrNil color: c
	"Draw the given string in the given font and color clipped to the given rectangle. If the font is nil, the default font is used."
	myCanvas
		text: s
		bounds: boundsRect
		font: fontOrNil
		color: (self mapColor: c)