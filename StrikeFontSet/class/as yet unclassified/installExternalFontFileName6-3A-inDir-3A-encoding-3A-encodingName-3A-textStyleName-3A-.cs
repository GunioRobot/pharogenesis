installExternalFontFileName6: fileName inDir: dir encoding: encoding encodingName: aString textStyleName: styleName

	| array fonts encodingIndex textStyle |
	array _ (ReferenceStream on: (dir readOnlyFileNamed: fileName)) next.
	TextConstants at: aString asSymbol put: array.

	textStyle _ TextConstants at: styleName asSymbol.
	encodingIndex _ encoding + 1.
	textStyle fontArray do: [:fs |
		fonts _ fs fontArray.
		encodingIndex > fonts size
			ifTrue: [fonts _  (Array new: encodingIndex)
				replaceFrom: 1 to: fonts size with: fonts startingAt: 1].
		fonts at: encodingIndex put: (self findMaximumLessThan: fs fontArray first in: array).
		fs initializeWithFontArray: fonts.
	].
