selectedClassOrMetaClass
	"Answer the selected class or metaclass."

	self metaClassIndicated
		ifTrue: [^ self selectedClass class]
		ifFalse: [^ self selectedClass]