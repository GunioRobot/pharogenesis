changeShortcut: shortcut to: aString
	aString isBlock ifTrue: [^self map at: shortcut put: aString].
	(aString startsWith: '[') ifTrue: [^self map at: shortcut put: aString].
	aString isEmpty ifTrue: [self map removeKey: shortcut ifAbsent: []]
				ifFalse: [self map at: shortcut put: aString]