viewContentsInWorkspace
	"View the contents of my selected file in a new workspace"
	
	| aString aFileStream aName |
	aString _ (aFileStream _ directory readOnlyFileNamed: self fullName) contentsOfEntireFile.
	aName _ aFileStream localName.
	aFileStream close.
	(Workspace new contents: aString) openLabel: 'Workspace from ', aName