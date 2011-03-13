selectedAnyFileDirectory
	"Answer the file directory for the selected file or, if none
	or not a directory, the selected file directory."

	^self selectedFileEntry
		ifNil: [self selectedFileDirectory]
		ifNotNilDo: [:fe | self selectedFileDirectory ifNotNilDo: [:fd |
					fe isDirectory ifTrue: [
						fd directoryNamed: fe name]]]