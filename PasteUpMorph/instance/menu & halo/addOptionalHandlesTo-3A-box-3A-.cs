addOptionalHandlesTo: aHalo box: box
	| aHandle |
	aHandle _ aHalo addHandleAt: box rightCenter color: Color lightGray.
	aHandle on: #mouseDown send: #paintBackground to: self.
"
	aHandle _ aHalo addHandleAt: box leftCenter color: Color veryVeryLightGray.
	aHandle on: #mouseDown send: #makeNewDrawingWithin to: self."