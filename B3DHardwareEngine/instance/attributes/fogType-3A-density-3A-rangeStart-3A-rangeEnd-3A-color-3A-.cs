fogType: aSymbol density: aNumber rangeStart: fogRangeStart rangeEnd: fogRangeEnd color: aColor
	"Set the current fog mode. aSymbol must be either one of #none, #linear, #exp, or #exp2."
	| type |
	type _ 0.
	aSymbol == #linear ifTrue:[type _ 1].
	aSymbol == #exp ifTrue:[type _ 2].
	aSymbol == #exp2 ifTrue:[type _ 3].
	self primRender: handle
		setFog: type
		density: aNumber asFloat
		rangeStart: fogRangeStart asFloat
		rangeEnd: fogRangeEnd asFloat
		color: aColor pixelValue32.