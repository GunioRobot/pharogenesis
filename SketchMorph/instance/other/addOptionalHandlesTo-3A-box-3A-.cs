addOptionalHandlesTo: aHalo box: box
	| aHandle |
	aHandle _ aHalo addHandleAt: box bottomLeft color: Color blue.
	aHandle on: #mouseDown send: #startRot:with: to: aHalo.
	aHandle on: #mouseStillDown send: #doRot:with: to: aHalo.

	aHandle _ aHalo addHandleAt: box rightCenter color: Color lightGray.
	aHandle on: #mouseDown send: #editDrawing to: aHalo target