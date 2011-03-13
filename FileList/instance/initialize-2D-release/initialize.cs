initialize
	super initialize.
	fileSelectionBlock := [ :entry :myPattern |
		entry isDirectory ifTrue: [
			false
		] ifFalse: [
			myPattern = '*' or: [myPattern match: entry name]
		]
	].
	dirSelectionBlock := [ :dirName | true].