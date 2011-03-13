selectedDirectoryName
	"Answer the name of the selected directory."

	^(self selectedFileDirectory ifNil: [^nil]) name