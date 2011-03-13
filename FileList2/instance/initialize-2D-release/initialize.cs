initialize

	showDirsInFileList _ false.
	fileSelectionBlock _ [ :entry :myPattern |
		entry isDirectory ifTrue: [
			showDirsInFileList
		] ifFalse: [
			myPattern = '*' or: [myPattern match: entry name]
		]
	] fixTemps.
	dirSelectionBlock _ [ :dirName | true].