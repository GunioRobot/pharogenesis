sendTextContentsBackToDonor
	"Send my string contents back to the Text Morph from whence I came"

	(self valueOfProperty: #donorTextMorph) ifNotNilDo:
		[:aDonor | aDonor setCharacters: self assuredPlayer getStringContents]