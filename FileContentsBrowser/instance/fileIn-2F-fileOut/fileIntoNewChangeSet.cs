fileIntoNewChangeSet
	| p ff |
	(p _ self selectedPackage) ifNil: [^ self beep].
	ff _ StandardFileStream readOnlyFileNamed: p fullPackageName.
	ChangeSorter newChangesFromStream: ff named: p packageName