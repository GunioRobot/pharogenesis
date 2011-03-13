externalFunctionDeclaration
	"Parse the function declaration for a call to an external library."
	| descriptorClass callType retType externalName args argType module fn |
	descriptorClass := Smalltalk at: #ExternalFunction ifAbsent:[nil].
	descriptorClass == nil ifTrue:[^false].
	callType := descriptorClass callingConventionFor: here.
	callType == nil ifTrue:[^false].
	"Parse return type"
	self advance.
	retType := self externalType: descriptorClass.
	retType == nil ifTrue:[^self expected:'return type'].
	"Parse function name or index"
	externalName := here.
	(self match: #string) 
		ifTrue:[externalName := externalName asSymbol]
		ifFalse:[(self match:#number) ifFalse:[^self expected:'function name or index']].
	(self matchToken: #'(') ifFalse:[^self expected:'argument list'].
	args := WriteStream on: Array new.
	[here == #')'] whileFalse:[
		argType := self externalType: descriptorClass.
		argType == nil ifTrue:[^self expected:'argument'].
		argType isVoid & argType isPointerType not ifFalse:[args nextPut: argType].
	].
	(self matchToken:#')') ifFalse:[^self expected:')'].
	(self matchToken: 'module:') ifTrue:[
		module := here.
		(self match: #string) ifFalse:[^self expected: 'String'].
		module := module asSymbol].
	Smalltalk at: #ExternalLibraryFunction ifPresent:[:xfn|
		fn := xfn name: externalName 
				module: module 
				callType: callType
				returnType: retType
				argumentTypes: args contents.
		self allocateLiteral: fn.
	].
	self addPragma: (Pragma keyword: #primitive: arguments: #(120)).
	^true