browseFiles
	| selectionPattern fileList |
	selectionPattern := FillInTheBlank request:'What files?' initialAnswer: self pattern.
	fileList _ (directory fileNamesMatching: selectionPattern) 
		collect: [:each | directory fullNameFor: each].
	FileContentsBrowser browseFiles: fileList.
