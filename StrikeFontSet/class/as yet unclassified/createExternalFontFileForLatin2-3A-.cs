createExternalFontFileForLatin2: fileName
"
	StrikeFontSet createExternalFontFileForLatin2: 'latin2.out'.
"

	| file array f installDirectory |
	file _ FileStream newFileNamed: fileName.
	installDirectory _ Smalltalk at: #M17nInstallDirectory ifAbsent: [].
	installDirectory _ installDirectory
		ifNil: [String new]
		ifNotNil: [installDirectory , FileDirectory pathNameDelimiter asString].
	array _ Array
				with: (StrikeFont newFromEFontBDFFile: installDirectory , 'b10.bdf' name: 'LatinTwo9' ranges: EFontBDFFontReaderForRanges rangesForLatin2)
				with: (StrikeFont newFromEFontBDFFile: installDirectory , 'b12.bdf' name: 'LatinTwo10' ranges: EFontBDFFontReaderForRanges rangesForLatin2)
				with: (StrikeFont newFromEFontBDFFile: installDirectory , 'b14.bdf' name: 'LatinTwo12' ranges: EFontBDFFontReaderForRanges rangesForLatin2)
				with: (StrikeFont newFromEFontBDFFile: installDirectory , 'b16.bdf' name: 'LatingTwo14' ranges: EFontBDFFontReaderForRanges rangesForLatin2)
				with: (StrikeFont newFromEFontBDFFile: installDirectory , 'b24.bdf' name: 'LatinTwo20' ranges: EFontBDFFontReaderForRanges rangesForLatin2).
	TextConstants at: #forceFontWriting put: true.
	f _ ReferenceStream on: file.
	f nextPut: array.
	file close.
	TextConstants removeKey: #forceFontWriting.
