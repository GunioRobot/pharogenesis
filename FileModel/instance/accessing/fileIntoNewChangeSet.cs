fileIntoNewChangeSet
	"FileIn all of the contents from the external file, into a new change set."
	| f |
	f _ FileStream oldFileNamed: self fullName.
	(self fileNameSuffix sameAs: 'html') ifTrue: [f _ f asHtml].
	ChangeSorter newChangesFromFileStream: f