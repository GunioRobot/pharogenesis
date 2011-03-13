viewContentsInWorkspace
	"View the contents of my selected file in a new workspace"
	
	| aString aFileStream aName |
	aString := (aFileStream := directory readOnlyFileNamed: self fullName) setConverterForCode contentsOfEntireFile.
	aName := aFileStream localName.
	aFileStream close.
	UIManager default edit: aString label: 'Workspace from ', aName