fromFormArray: formArray asciiStart: asciiStart ascent: ascentVal
	| height width x badChar |
	type _ 2.
	name _ 'aFormFont'.
	minAscii _ asciiStart.
	maxAscii _ minAscii + formArray size - 1.
	ascent _ ascentVal.
	subscript _ superscript _ emphasis _ 0.
	height _ width _ 0.
	maxWidth _ 0.
	formArray do:
		[:f | width _ width + f width.
		maxWidth _ maxWidth max: f width.
		height _ height max: f height + f offset y].
	badChar _ (Form extent: 7@height) borderWidth: 1.
	width _ width + badChar width.
	descent _ height - ascent.
	pointSize _ height.
	glyphs _ Form extent: width @ height depth: formArray first depth.
	xTable _ Array new: maxAscii + 3 withAll: 0.
	x _ 0.
	formArray doWithIndex:
		[:f :i | f displayOn: glyphs at: x@0.
		xTable at: minAscii + i+1 put: (x _ x + f width)].
	badChar displayOn: glyphs at: x@0.
	xTable at: maxAscii + 3 put: x + badChar width.
	self setStopConditions