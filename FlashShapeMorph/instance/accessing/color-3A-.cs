color: aColor
	| fillStyle |
	color := aColor.
	fillStyle := SolidFillStyle color: aColor.
	shape := shape copyAndCollectFills:[:fill| fillStyle]