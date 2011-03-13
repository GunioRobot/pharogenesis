doubleClickFile
	"If the selected entry is a directory then navigate it
	otherwise ok the dialog."
	
	|fe de sm|
	fe := self selectedFileEntry.
	fe ifNil: [^self].
	fe isDirectory
		ifTrue: [de := self selectedFileDirectory.
				sm := self directoryTreeMorph selectedMorph.
				self changed: #(openPath), de pathParts.
				self selectedDirectory: (sm children detect: [:w |
					w complexContents item localName = fe name]) complexContents]
		ifFalse: [self ok]