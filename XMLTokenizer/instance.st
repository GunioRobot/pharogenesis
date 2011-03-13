Object
	subclass: #XMLTokenizer
	instanceVariableNames:
		'stream nestedStreams entities externalEntities parameterEntities parsingMarkup markedPosition peekChar validating nameBuffer attributeBuffer'
	classVariableNames: 'CharEscapes DigitTable LiteralChars NameDelimiters SeparatorTable'
	poolDictionaries: ''
	category: 'XML-Parser'