postscriptFontInfoForFont: font

	| fontName decoded desired mask decodedName keys match |

	fontName _ font textStyleName asString.
	decoded _ TextStyle decodeStyleName: fontName.
	decodedName _ decoded second.
	keys _ self fontMap keys asArray sort: [ :a :b | a size > b size ].

	match _ keys select: [ :k | decoded first = k or: [ fontName = k ] ].
	match do: [ :key | | subD |
		subD := self fontMap at: key.
		desired _ font emphasis.
		mask _ 31.
		[
			desired _ desired bitAnd: mask.
			subD at: desired ifPresent: [ :answer | ^answer].
			mask _ mask bitShift: -1.
			desired > 0
		] whileTrue.
	].

	"No explicit lookup found; try to convert the style name into the canonical Postscript name.
	This name will probably still be wrong."

	fontName _ String streamContents: [ :s |
		s nextPutAll: decodedName.
		decoded third do: [ :nm | s nextPut: $-; nextPutAll: nm ].

		(font emphasis == 0 and: [ (decoded last includes: 0) not ])
			ifTrue: [ s nextPutAll:  '-Regular' ].

		(font emphasis == 1 and: [ (decoded first anyMask: 1) not ])
			ifTrue: [ s nextPutAll:  '-Bold' ].

		(font emphasis == 2 and: [ (decoded first anyMask: 2) not ])
			ifTrue: [ s nextPutAll:  '-Italic' ].

		(font emphasis == 3 and: [ (decoded first anyMask: 3) not ])
			ifTrue: [ s nextPutAll:  '-BoldItalic' ].
	].

	^ {fontName. 1.0}
