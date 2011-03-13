codeStringForPrimitives: classAndSelectorList

	| sel aClass source s verbose meth |
	self initialize.
	classAndSelectorList do: [:classAndSelector |
		aClass _ Smalltalk at: (classAndSelector at: 1).
		self addClassVarsFor: aClass.
		sel _ classAndSelector at: 2.
		(aClass includesSelector: sel)
			ifTrue: [source _ aClass sourceCodeAt: sel]
			ifFalse: [source _ aClass class sourceCodeAt: sel].
		meth _ ((Compiler new parse: source in: aClass notifying: nil)
				asTMethodFromClass: aClass).
		meth primitive > 0 ifTrue: [meth preparePrimitiveInClass: aClass].
		"for old-style array accessing:
			meth covertToZeroBasedArrayReferences."
		meth replaceSizeMessages.
		self addMethod: meth].

	"method preparation"
	verbose _ false.
	self prepareMethods.
	verbose ifTrue: [
		self printUnboundCallWarnings.
		self printUnboundVariableReferenceWarnings.
		Transcript cr].

	"code generation"
	self doInlining: true.
	s _ ReadWriteStream on: (String new: 1000).
	methods _ methods asSortedCollection: [:m1 :m2 | m1 selector < m2 selector].
	self emitCHeaderForPrimitivesOn: s.
	self emitCVariablesOn: s.
	self emitCFunctionPrototypesOn: s.
	methods do: [:m | m emitCCodeOn: s generator: self].
	^ s contents
