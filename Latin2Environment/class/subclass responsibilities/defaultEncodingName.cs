defaultEncodingName
	| platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current  getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) ifTrue: [^'utf-8' copy].
	(#('Win32') includes: platformName) 
		ifTrue: [^'cp-1250' copy].
	(#('unix') includes: platformName) ifTrue: [^'iso8859-2' copy].
	^'mac-roman'