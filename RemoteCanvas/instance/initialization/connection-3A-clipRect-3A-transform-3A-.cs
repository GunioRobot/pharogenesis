connection: connection0 clipRect: clipRect0 transform: transform0
	connection _ connection0.
	outerClipRect _ clipRect0.
	transform _ transform0.


	innerClipRect := transform globalBoundsToLocal: outerClipRect. 