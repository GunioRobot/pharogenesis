fileIntoNewChangeSet
	| p ff |
	(p _ self selectedPackage) ifNil: [^ Beeper beep].
	ff _ FileStream readOnlyFileNamed: p fullPackageName.
	ChangeSorter newChangesFromStream: ff named: p packageName