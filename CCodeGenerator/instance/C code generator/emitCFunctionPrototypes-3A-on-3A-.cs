emitCFunctionPrototypes: methodList on: aStream 
	"Store prototype declarations for all non-inlined methods on the given stream."
	| exporting |
	aStream nextPutAll: '/*** Function Prototypes ***/'; cr.
	isCPP ifTrue: [aStream nextPutAll: 'extern "C" {'; cr].
	exporting _ false.
	methodList do: [:m | 
		m export
			ifTrue: [exporting
					ifFalse: 
						[aStream nextPutAll: '#pragma export on'; cr.
						exporting _ true]]
			ifFalse: [exporting
					ifTrue: 
						[aStream nextPutAll: '#pragma export off'; cr.
						exporting _ false]].
		m emitCFunctionPrototype: aStream generator: self.
		aStream nextPutAll: ';'; cr].
	exporting ifTrue: [aStream nextPutAll: '#pragma export off'; cr].
	isCPP ifTrue: [aStream nextPutAll: '}'; cr]