codeStringForPrimitives: classAndSelectorList

	| sel aClass source s verbose meth |
	self initialize.
	classAndSelectorList do: [ :classAndSelector |
		aClass _ Smalltalk at: (classAndSelector at: 1).
		self addClassVarsFor: aClass.
		sel _ classAndSelector at: 2.
		source _ aClass sourceCodeAt: sel.
		meth _ ((Compiler new parse: source in: aClass notifying: nil)
				asTMethodFromClass: aClass).
		meth preparePrimitiveInClass: aClass.
		self addMethod: meth.
	].
	s _ ReadWriteStream on: (String new: 1000).

	"method preparation"
	verbose _ false.
	self prepareMethods.
	verbose ifTrue: [
		self printUnboundCallWarnings.
		self printUnboundVariableReferenceWarnings.
		Transcript cr.
	].

	"code generation"
	methods _ methods asSortedCollection: [ :m1 :m2 | m1 selector < m2 selector ].
	self emitCHeaderForPrimitivesOn: s.
	self emitCVariablesOn: s.
	self emitCFunctionPrototypesOn: s.
	methods do: [ :m | m emitCCodeOn: s generator: self ].
	^ s contents