fileIntoNewChangeSet
	"File in all of the contents of the currently selected file, if any, into a new change set."

	| ff |
	listIndex = 0 ifTrue: [^ self].
	ff _ directory oldFileNamed: self fullName.
	(self fileNameSuffix sameAs: 'html') ifTrue: [ff _ ff asHtml].
	ChangeSorter newChangesFromStream: ff named: fileName.
