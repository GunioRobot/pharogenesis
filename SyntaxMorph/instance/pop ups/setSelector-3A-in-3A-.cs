setSelector: stringLike in: stringMorph
	"Store the new selector and accept method."

	| aSymbol myType str |
	aSymbol _ stringLike asSymbol.
	(ScriptingSystem helpStringOrNilFor: aSymbol) ifNotNilDo:
		[:aString |
			self setBalloonText: aString translated].
	myType _ stringMorph valueOfProperty: #syntacticReformatting ifAbsent: [#none].
	str _ aSymbol.
	(self isStandardSetterKeyword: str) ifTrue: [str _ self translateToWordySetter: str].
	(self isStandardGetterSelector: str) ifTrue: [str _ self translateToWordyGetter: str].
	(self shouldBeBrokenIntoWords: myType) 
		ifTrue: [str _ self substituteKeywordFor: str].
	stringMorph contents: str.
	"parseNode key: aSymbol code: nil."
	str = stringLike ifFalse:
		[stringMorph setProperty: #syntacticallyCorrectContents toValue: aSymbol].
	self acceptSilently