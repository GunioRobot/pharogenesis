selectedClassOrMetaClass
	"Answer the selected class or metaclass."

	self metaClassIndicated
		ifTrue: [^ self selectedClass metaClass]
		ifFalse: [^ self selectedClass]