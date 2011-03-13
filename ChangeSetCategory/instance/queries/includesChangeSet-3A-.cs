includesChangeSet: aChangeSet
	"Answer whether the receiver includes aChangeSet in its retrieval list"

	^ ChangesOrganizer perform: membershipSelector with: aChangeSet