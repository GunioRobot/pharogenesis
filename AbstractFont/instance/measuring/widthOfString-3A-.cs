widthOfString: aString

	^ self composeWord: (1 to: aString size) in: aString beginningAt: 0
"
	TextStyle default defaultFont widthOfString: 'zort' 21
"