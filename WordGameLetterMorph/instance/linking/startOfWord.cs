startOfWord

	(predecessor == nil or: [predecessor isBlank]) ifTrue: [^ self].
	^ predecessor startOfWord