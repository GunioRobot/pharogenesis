asFormWithScale: scale ascender: ascender descender: descender fgColor: fgColor bgColor: bgColor
	| form canvas |
	form _ Form extent: (advanceWidth @ (ascender - descender) * scale) rounded depth: 8.
	form fillColor: bgColor.
	canvas _ BalloonCanvas on: form.
	canvas aaLevel: 4.
	canvas transformBy: (MatrixTransform2x3 withScale: scale asPoint * (1 @ -1)).
	canvas transformBy: (MatrixTransform2x3 withOffset: 0 @ ascender negated).
	canvas
		drawGeneralBezierShape: self contours
		color: fgColor 
		borderWidth: 0 
		borderColor: fgColor.
	form replaceColor: bgColor withColor: Color transparent.
	^ form