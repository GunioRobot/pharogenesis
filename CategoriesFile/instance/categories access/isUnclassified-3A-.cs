isUnclassified: messageID
	"Answer true if the given message ID does not appear in any of my real (not pseudo) categories."

	categories do:
		[: category | (category includes: messageID) ifTrue: [^false]].
	^true