remove: aVersion ifAbsent: aBlock
	"Remove aVersion from this version history."

	(versions includes: aVersion) ifFalse: [^aBlock value].

	(self canRemove: aVersion) ifFalse:
		[^self error: 'Only versions at the beginning or end with no more than one follower may be removed'].

	versions remove: aVersion.