emitCFunctionPrototypesOn: aStream
	"Store prototype declarations for all non-inlined methods on the given stream."

	aStream nextPutAll: '/*** Function Prototypes ***/'; cr.
	methods do: [ :m |
		m emitCFunctionPrototype: aStream generator: self.
		aStream nextPutAll: ';'; cr.
	].