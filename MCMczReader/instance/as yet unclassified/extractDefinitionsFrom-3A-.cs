extractDefinitionsFrom: member
	| reader |
	(MCSnapshotReader readerClassForFileNamed: member fileName)
		ifNotNil: [:rc | reader := rc on: member contentStream text.
					definitions addAll: reader definitions]
