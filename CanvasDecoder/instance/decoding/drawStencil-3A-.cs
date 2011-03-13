drawStencil: command
	| stencilFormEnc locationEnc sourceRectEnc colorEnc stencilForm location sourceRect color |
	stencilFormEnc := command at: 2.
	locationEnc := command at: 3.
	sourceRectEnc := command at: 4.
	colorEnc := command at: 5.

	stencilForm := self class decodeImage: stencilFormEnc.
	location := self class decodePoint: locationEnc.
	sourceRect := self class decodeRectangle: sourceRectEnc.
	color := self class decodeColor: colorEnc.

	self drawCommand: [ :executor |
		executor stencil: stencilForm at: location sourceRect: sourceRect  color: color ]