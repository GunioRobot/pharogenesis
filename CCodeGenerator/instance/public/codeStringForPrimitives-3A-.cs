codeStringForPrimitives: classAndSelectorList 
	| sel aClass source s verbose meth methodList |
	self initialize.
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

		"if this method is supposed to be a primitive (rather than a helper 
		routine), add assorted prolog and epilog items"
		meth primitive > 0 ifTrue: [meth preparePrimitiveInClass: aClass].
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
	s _ ReadWriteStream on: (String new: 1000).
	methodList _ methods asSortedCollection: [:m1 :m2 | m1 selector < m2 selector].
	self emitCHeaderForPrimitivesOn: s.
	self emitCVariablesOn: s.
	self emitCFunctionPrototypes: methodList on: s.
	methodList do: [:m | m emitCCodeOn: s generator: self].
	^ s contents