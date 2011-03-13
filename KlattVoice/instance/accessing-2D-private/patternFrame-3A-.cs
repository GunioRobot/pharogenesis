patternFrame: aKlattFrame
	patternFrame isNil ifTrue: [patternFrame := aKlattFrame. ^ self].
	patternFrame replaceFrom: 1 to: patternFrame size with: aKlattFrame