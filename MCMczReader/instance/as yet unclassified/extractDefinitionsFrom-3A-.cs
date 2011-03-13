extractDefinitionsFrom: member
	| reader |
	(MCSnapshotReader readerClassForFileNamed: member fileName)
		ifNotNilDo: [:rc | reader := rc on: member contentStream text.
					definitions addAll: reader definitions]
