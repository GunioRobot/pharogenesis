emitCCodeOn: aStream generator: aCodeGen
	"Emit C code for this method onto the given stream. All calls to inlined methods should already have been expanded."

	self emitCCommentOn: aStream.	"place method comment before function"

	self emitCHeaderOn: aStream generator: aCodeGen.
	parseTree emitCCodeOn: aStream level: 1 generator: aCodeGen.
	aStream nextPutAll: '}'; cr.