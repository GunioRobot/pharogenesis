emitCHeaderOn: aStream generator: aCodeGen
	"Emit a C function header for this method onto the given stream."

	aStream cr. 
	self emitCFunctionPrototype: aStream generator: aCodeGen.
	aStream nextPutAll: ' {'; cr.
	self emitGlobalStructReferenceOn: aStream.
	locals do: [ :var |
		aStream nextPutAll: '    '.
		aStream nextPutAll: (declarations at: var ifAbsent: [ 'int ', var]), ';'; cr.
	].
	locals isEmpty ifFalse: [ aStream cr ].