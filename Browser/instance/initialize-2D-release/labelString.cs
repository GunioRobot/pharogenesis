labelString
	^self selectedClass ifNil: [ self defaultBrowserTitle ]
		ifNotNil: [ self defaultBrowserTitle, ': ', self selectedClass printString ].
