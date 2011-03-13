stringForTheme: aTheme 

	^ (aTheme == ColorTheme current class
		ifTrue: ['<on>']
		ifFalse: ['<off>'])
		, aTheme themeName translated.