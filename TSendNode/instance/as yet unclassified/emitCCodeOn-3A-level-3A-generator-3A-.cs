emitCCodeOn: aStream level: level generator: aCodeGen

	"If the selector is a built-in construct, translate it and return"
	(aCodeGen emitBuiltinConstructFor: self on: aStream level: level) ifTrue: [ ^self ].

	"Special case for pluggable modules. Replace messages to interpreterProxy
	by interpreterProxy->message(..) if the message is not builtin"
	(aCodeGen isGeneratingPluginCode and:[
		receiver isVariable and:[
			'interpreterProxy' = receiver name and:[
				self isBuiltinOperator not]]]) 
		ifTrue:[aStream nextPutAll:'interpreterProxy->'].
	"Translate this message send into a C function call."
	aStream nextPutAll: (aCodeGen cFunctionNameFor: selector), '('.
	(receiver isVariable and:
	 [('self' = receiver name) or: ['interpreterProxy' = receiver name]]) ifFalse: [
		"self is omitted from the arguments list of the generated call"
		"Note: special case for translated BitBltSimulator--also omit
		 the receiver if this is a send to the variable 'interpreterProxy'"
		receiver emitCCodeOn: aStream level: level generator: aCodeGen.
		arguments isEmpty ifFalse: [ aStream nextPutAll: ', ' ].
	].
	1 to: arguments size do: [ :i |
		(arguments at: i) emitCCodeOn: aStream level: level generator: aCodeGen.
		i < arguments size ifTrue: [ aStream nextPutAll: ', ' ].
	].
	aStream nextPutAll: ')'.