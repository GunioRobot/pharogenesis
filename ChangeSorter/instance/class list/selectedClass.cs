selectedClass

	^ currentClassName ifNil: [nil]
		ifNotNil: [self selectedClassOrMetaClass theNonMetaClass]