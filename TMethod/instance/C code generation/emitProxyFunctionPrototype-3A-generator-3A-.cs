emitProxyFunctionPrototype: aStream generator: aCodeGen
	"Emit an indirect C function header for this method onto the given stream."

	| arg |
	aStream nextPutAll: returnType; space.
	aStream nextPutAll: '(*', (aCodeGen cFunctionNameFor: selector), ')('.
	args isEmpty ifTrue: [ aStream nextPutAll: 'void' ].
	1 to: args size do: [ :i |
		arg _ args at: i.
		(declarations includesKey: arg) ifTrue: [
			aStream nextPutAll: (declarations at: arg).
		] ifFalse: [
			aStream nextPutAll: 'int ', (args at: i).
		].
		i < args size ifTrue: [ aStream nextPutAll: ', ' ].
	].
	aStream nextPutAll: ')'.