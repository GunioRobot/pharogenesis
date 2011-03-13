newChangeSetFromStream: aStream named: aName 

	"This code is based upon ChangeSet-c-#newChangesFromStream:named: which is in 3.9,
	implemented here for previous versions. The second branch is for 3.8, where ChangeSets
	are loaded by ChangeSorter. "

	| oldChanges newName newSet newStream |

	(self classChangeSet respondsTo: #newChangesFromStream:named:) 
		ifTrue: [ ^self classChangeSet newChangesFromStream: aStream named:aName ].

	(self classChangeSorter respondsTo: #newChangesFromStream:named:)
		ifTrue: [ ^self classChangeSorter newChangesFromStream: aStream named: aName ].

	oldChanges := ChangeSet current.
 
	"so a Bumper update can find it"
	newName := aName sansPeriodSuffix.

	newSet := self classChangeSet basicNewNamed: newName.

	[newSet
		ifNotNil: [(aStream respondsTo: #converter:)
				ifTrue: [newStream := aStream]
				ifFalse: [newStream := self classMultiByteBinaryOrTextStream with: aStream contentsOfEntireFile.
					newStream reset].
			self classChangeSet newChanges: newSet.
			newStream setConverterForCode.
			newStream fileInAnnouncing: 'Loading ' , newName , '...'.
			Transcript cr; show: 'File ' , aName , ' successfully filed in to change set ' , newName].
	aStream close]
		ensure: [self classChangeSet newChanges: oldChanges].
	 
	^ newSet