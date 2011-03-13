fileIntoNewChangeSet
	"File in all of the contents of the currently selected file,
	if any, into a new change set." 

	| fn ff |
	listIndex = 0 ifTrue: [^ self].
	ff _ directory readOnlyFileNamed: (fn _ self uncompressedFileName).
	((self getSuffix: fn) sameAs: 'html') ifTrue: [ff _ ff asHtml].
	ChangeSorter newChangesFromStream: ff named: (directory localNameFor: fn)