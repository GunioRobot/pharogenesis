fileIntoChangeSetNamed: aString fromStream: stream
	"We let the user confirm filing into an existing ChangeSet
	or specify another ChangeSet name if
	the name derived from the filename already exists."
	
	| changeSet newName oldChanges global |
	newName := aString.
	changeSet := SMInstaller changeSetNamed: newName.
	changeSet ifNotNil: [
		newName := self silent ifNil: [UIManager default
									request: 'ChangeSet already present, just confirm to overwrite or enter a new name:' 
									initialAnswer: newName]
						ifNotNil: [newName].
		newName isEmpty ifTrue:[self error: 'Cancelled by user'].
		changeSet := SMInstaller changeSetNamed: newName].
		changeSet ifNil:[changeSet := SMInstaller basicNewChangeSet: newName].
		changeSet ifNil:[self error: 'User did not specify a valid ChangeSet name'].
		oldChanges := (SystemVersion current highestUpdate < 5302)
						ifFalse: [global := ChangeSet. ChangeSet current]
						ifTrue: [global := Smalltalk. Smalltalk changes].
 		[global newChanges: changeSet.
		stream fileInAnnouncing: 'Loading ', newName, ' into change set ''', newName, ''''.
		stream close] ensure: [global newChanges: oldChanges]