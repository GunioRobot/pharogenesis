removeStyleName: aString

	| style symName |
	symName _ aString asSymbol.
	style _ TextConstants removeKey: symName ifAbsent: [].
	style ifNotNil: [self unregister: symName].
	TTCFontDescription removeDescriptionNamed: aString asString.
