initialize
	translationDict _ Dictionary new.
	inlineList _ Array new.
	constants _ Dictionary new: 100.
	variables _ OrderedCollection new: 100.
	variableDeclarations _ Dictionary new: 100.
	methods _ Dictionary new: 500.
	self initializeCTranslationDictionary.
	headerFiles _ OrderedCollection new.
	globalVariableUsage _ Dictionary new.
	useSymbolicConstants _ true.
	generateDeadCode _ true.