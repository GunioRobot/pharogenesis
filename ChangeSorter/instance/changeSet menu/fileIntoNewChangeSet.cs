fileIntoNewChangeSet
	"Obtain a file designation from the user, and file its contents into a new change set whose name is a function of the filename.  Show the new set and leave the current changeSet unaltered."
	| aFileName  aNewChangeSet |

	self okToChange ifFalse: [^ self].
	aFileName _ FillInTheBlank request: 'Name of file to be imported: '.
	aFileName size == 0 ifTrue: [^ self].
	(FileDirectory default fileExists: aFileName) ifFalse:
		[^ self inform: 'Sorry -- cannot find that file'].

	aNewChangeSet _ self class 
			newChangesFromStream: (FileStream oldFileNamed: aFileName) 
			named: aFileName.
	aNewChangeSet ifNotNil: [self showChangeSet: aNewChangeSet]