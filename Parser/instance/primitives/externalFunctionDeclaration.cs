externalFunctionDeclaration
	"Parse the function declaration for a call to an external library."
	| descriptorClass callType retType externalName args argType module fn |
	descriptorClass _ Smalltalk at: #ExternalFunction ifAbsent:[nil].
	descriptorClass == nil ifTrue:[^0].
	callType _ descriptorClass callingConventionFor: here.
	callType == nil ifTrue:[^0].
	"Parse return type"
	self advance.
	retType _ self externalType: descriptorClass.
	retType == nil ifTrue:[^self expected:'return type'].
	"Parse function name or index"
	externalName _ here.
	(self match: #string) 
		ifTrue:[externalName _ externalName asSymbol]
		ifFalse:[(self match:#number) ifFalse:[^self expected:'function name or index']].
	(self matchToken:'(' asSymbol) ifFalse:[^self expected:'argument list'].
	args _ WriteStream on: Array new.
	[here == #')'] whileFalse:[
		argType _ self externalType: descriptorClass.
		argType == nil ifTrue:[^self expected:'argument'].
		argType isVoid & argType isPointerType not ifFalse:[args nextPut: argType].
	].
	(self matchToken:')' asSymbol) ifFalse:[^self expected:')'].
	(self matchToken: 'module:') ifTrue:[
		module _ here.
		(self match: #string) ifFalse:[^self expected: 'String'].
		module _ module asSymbol].
	Smalltalk at: #ExternalLibraryFunction ifPresent:[:xfn|
		fn _ xfn name: externalName 
				module: module 
				callType: callType
				returnType: retType
				argumentTypes: args contents.
		self allocateLiteral: fn.
	].
	^120