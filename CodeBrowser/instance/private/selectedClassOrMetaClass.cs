selectedClassOrMetaClass
	^ metaClassIndicated
		ifTrue: [self selectedClass class]
		ifFalse: [self selectedClass]