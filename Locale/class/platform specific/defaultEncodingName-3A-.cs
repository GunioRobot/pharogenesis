defaultEncodingName: languageSymbol 
	| encodings platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	encodings := self platformEncodings at: languageSymbol
				ifAbsent: [self platformEncodings at: #default].
	encodings at: platformName ifPresent: [:encoding | ^encoding].
	encodings at: platformName , ' ' , osVersion
		ifPresent: [:encoding | ^encoding].
	^encodings at: #default