patternFrame: aKlattFrame
	patternFrame isNil ifTrue: [patternFrame _ aKlattFrame. ^ self].
	patternFrame replaceFrom: 1 to: patternFrame size with: aKlattFrame