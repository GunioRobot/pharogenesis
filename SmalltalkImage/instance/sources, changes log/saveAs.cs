saveAs
	"Put up the 'saveAs' prompt, obtain a name, and save the image  under that new name."

	| newName |
	newName _ self getFileNameFromUser.
	newName isNil ifTrue: [^ self].
	(SourceFiles at: 2) ifNotNil:
		[self closeSourceFiles; "so copying the changes file will always work"
			 saveChangesInFileNamed: (self fullNameForChangesNamed: newName)].
	self saveImageInFileNamed: (self fullNameForImageNamed: newName)