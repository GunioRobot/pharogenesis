initialize

	translationDict _ Dictionary new.
	inlineList _ Array new.
	constants _ Dictionary new.
	variables _ OrderedCollection new.
	variableDeclarations _ Dictionary new.
	methods _ Dictionary new.
	self initializeCTranslationDictionary.