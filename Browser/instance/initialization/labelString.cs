labelString
	^self selectedClass ifNil: [ self defaultBrowserTitle ]
		ifNotNil: [ self selectedClass printString ].
