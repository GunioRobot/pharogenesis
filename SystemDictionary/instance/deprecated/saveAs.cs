saveAs
	"Put up the 'saveAs' prompt, obtain a name, and save the image  under that new name."

	| newName |
	self deprecated: 'Use SmalltalkImage current saveAs'.
	newName _ SmalltalkImage current getFileNameFromUser.
	newName isNil ifTrue: [^ self].
	(SourceFiles at: 2) ifNotNil:
		[SmalltalkImage current closeSourceFiles; "so copying the changes file will always work"
			 saveChangesInFileNamed: (SmalltalkImage current fullNameForChangesNamed: newName)].
	SmalltalkImage current saveImageInFileNamed: (SmalltalkImage current fullNameForImageNamed: newName)