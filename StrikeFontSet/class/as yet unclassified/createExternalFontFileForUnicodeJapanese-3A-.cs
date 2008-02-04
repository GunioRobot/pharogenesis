createExternalFontFileForUnicodeJapanese: fileName
"
	StrikeFontSet createExternalFontFileForUnicodeJapanese: 'uJapaneseFont.out'.
"

	| file array f installDirectory |
	file := FileStream newFileNamed: fileName.
	installDirectory := Smalltalk at: #M17nInstallDirectory ifAbsent: [].
	installDirectory := installDirectory
		ifNil: [String new]
		ifNotNil: [installDirectory , FileDirectory pathNameDelimiter asString].
	array := Array
				with: (StrikeFont newForJapaneseFromEFontBDFFile: installDirectory , 'b12.bdf' name: 'Japanese10' overrideWith: 'shnmk12.bdf')
				with: ((StrikeFont newForJapaneseFromEFontBDFFile: installDirectory , 'b14.bdf' name: 'Japanese12' overrideWith: 'shnmk14.bdf') "fixAscent: 14 andDescent: 1 head: 1")
				with: ((StrikeFont newForJapaneseFromEFontBDFFile: 'b16.bdf' name: 'Japanese14' overrideWith: 'shnmk16.bdf') "fixAscent: 16 andDescent: 4 head: 4")
				with: (StrikeFont newForJapaneseFromEFontBDFFile: installDirectory , 'b24.bdf' name: 'Japanese18' overrideWith: 'kanji24.bdf').
	TextConstants at: #forceFontWriting put: true.
	f := ReferenceStream on: file.
	f nextPut: array.
	file close.
	TextConstants removeKey: #forceFontWriting.
