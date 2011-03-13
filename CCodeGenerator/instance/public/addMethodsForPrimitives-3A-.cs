addMethodsForPrimitives: classAndSelectorList 
	| sel aClass source verbose meth |
	classAndSelectorList do: 
		[:classAndSelector | 
		aClass _ Smalltalk at: (classAndSelector at: 1).
		self addAllClassVarsFor: aClass.
"TPR - should pool vars also be added here?"

		"find the method in either the class or the metaclass"
		sel _ classAndSelector at: 2.
		(aClass includesSelector: sel)
			ifTrue: [source _ aClass sourceCodeAt: sel]
			ifFalse: [source _ aClass class sourceCodeAt: sel].

		"compile the method source and convert to a suitable translation 
		method "
		meth _ (Compiler new
					parse: source
					in: aClass
					notifying: nil)
					asTranslationMethodOfClass: self translationMethodClass.

		(aClass includesSelector: sel)
			ifTrue: [meth definingClass: aClass]
			ifFalse: [meth definingClass: aClass class].
		meth primitive > 0 ifTrue:[meth preparePrimitiveName].
		"for old-style array accessing: 
		meth covertToZeroBasedArrayReferences."
		meth replaceSizeMessages.
		self addMethod: meth].

	"method preparation"
	verbose _ false.
	self prepareMethods.
	verbose
		ifTrue: 
			[self printUnboundCallWarnings.
			self printUnboundVariableReferenceWarnings.
			Transcript cr].

	"code generation"
	self doInlining: true.

	methods do:[:m|
		"if this method is supposed to be a primitive (rather than a helper 
		routine), add assorted prolog and epilog items"
		m primitive > 0 ifTrue: [m preparePrimitivePrologue]].