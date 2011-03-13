addOptionalHandlesTo: aHalo box: box

	| aHandle |
	aHandle _ aHalo addHandleAt: box rightCenter color: Color lightGray.
	aHandle on: #mouseDown send: #editDrawing to: aHalo target renderedMorph
