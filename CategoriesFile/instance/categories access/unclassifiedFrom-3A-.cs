unclassifiedFrom: messageIDs
	"Answer the subset of the given set of message ID's that do not appear in any category."

	^messageIDs select:
		[: msgID | self isUnclassified: msgID]