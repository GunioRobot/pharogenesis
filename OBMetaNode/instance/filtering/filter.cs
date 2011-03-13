filter
	filterClass ifNil: [filterClass _ OBFilter].
	^ filterClass forMetaNode: self