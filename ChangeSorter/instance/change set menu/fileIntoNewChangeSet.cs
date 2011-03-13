fileIntoNewChangeSet
	"Obtain a file designation from the user, and file its contents into a new change set whose name is a function of the filename; in the end, leave the current change-set unaltered.  5/30/96 sw."

	| aFileName  aNewChangeSet |

	aFileName _ FillInTheBlank request: 'Name of file to be imported: '.
	aFileName size == 0 ifTrue: [^ self].
	(FileDirectory default includesKey: aFileName) ifFalse:
		[self inform: 'Sorry -- cannot find that file'.
		^ self].

	aNewChangeSet _ self class newChangesFromFile: aFileName.
	aNewChangeSet ~~ nil ifTrue:
		[myChangeSet _ aNewChangeSet.
		buttonView label: aNewChangeSet name asParagraph.
		buttonView display.
		self changed: #set]