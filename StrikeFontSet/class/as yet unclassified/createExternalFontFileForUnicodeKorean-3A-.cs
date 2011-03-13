createExternalFontFileForUnicodeKorean: fileName
"
	Smalltalk garbageCollect.
	StrikeFontSet createExternalFontFileForUnicodeKorean: 'uKoreanFont.out'.
"

	| file array f installDirectory |
	file _ FileStream newFileNamed: fileName.
	installDirectory _ Smalltalk at: #M17nInstallDirectory ifAbsent: [].
	installDirectory _ installDirectory
		ifNil: [String new]
		ifNotNil: [installDirectory , FileDirectory pathNameDelimiter asString].
	array _ Array
				with: (StrikeFont newForKoreanFromEFontBDFFile: installDirectory , 'b12.bdf' name: 'Japanese10' overrideWith: 'shnmk12.bdf')
				with: ((StrikeFont newForKoreanFromEFontBDFFile: installDirectory , 'b14.bdf' name: 'Japanese12' overrideWith: 'shnmk14.bdf') "fixAscent: 14 andDescent: 1 head: 1")
				with: ((StrikeFont newForKoreanFromEFontBDFFile: installDirectory , 'b16.bdf' name: 'Japanese14' overrideWith: 'hanglg16.bdf') fixAscent: 16 andDescent: 4 head: 4)
				with: (StrikeFont newForKoreanFromEFontBDFFile: installDirectory , 'b24.bdf' name: 'Japanese18' overrideWith: 'hanglm24.bdf').
	TextConstants at: #forceFontWriting put: true.
	f _ ReferenceStream on: file.
	f nextPut: array.
	file close.
	TextConstants removeKey: #forceFontWriting.
