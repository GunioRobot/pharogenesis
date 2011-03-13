reconstituteList
	"Clear out the receiver's elements and rebuild them"

	| newMembers |
	"First determine newMembers and check if they have not changed..."
	newMembers := ChangeSorter allChangeSets select:
		[:aChangeSet | ChangeSorter perform: membershipSelector withArguments: { aChangeSet }, parameters].
	(newMembers collect: [:cs | cs name]) = keysInOrder ifTrue: [^ self  "all current"].

	"Things have changed.  Need to recompute the whole category"
	self clear.
	newMembers do:
		[:aChangeSet | self fasterElementAt: aChangeSet name asSymbol put: aChangeSet]