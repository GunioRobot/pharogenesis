includesChangeSet: aChangeSet
	"Answer whether the receiver includes aChangeSet in its retrieval list"

	^ ChangeSorter perform: membershipSelector with: aChangeSet