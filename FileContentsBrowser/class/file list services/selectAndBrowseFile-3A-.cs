selectAndBrowseFile: aFileList
	"When no file are selected you can ask to browse several of them"

	| selectionPattern files |
	selectionPattern := FillInTheBlank request:'What files?' initialAnswer: '*.cs;*.st'.
	files _ (aFileList directory fileNamesMatching: selectionPattern) 
				collect: [:each | aFileList directory fullNameFor: each].
	self browseFiles: files.


