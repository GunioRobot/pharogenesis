color: aColor
	| fillStyle |
	color _ aColor.
	fillStyle _ SolidFillStyle color: aColor.
	shape _ shape copyAndCollectFills:[:fill| fillStyle]