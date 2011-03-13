testRectangleFillTiming
| r fillColor borderWidth borderColor t |
"
CanvasEncoder new testRectangleFillTiming
"
	r _ 100@100 extent: 300@300.
	fillColor _ Color blue.
	borderWidth _ 1.
	borderColor _ Color red.
	t _ Time millisecondsToRun: [
		1000 timesRepeat: [
		{
		String with: CanvasEncoder codeRect.
		self class encodeRectangle: r.
		self class encodeColor: fillColor.
		self class encodeInteger: borderWidth.
		self class encodeColor: borderColor }
		].
	].
	t inspect.