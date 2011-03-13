selectedClassOrMetaClass
	"Answer the selected class or metaclass."

	metaClassIndicated
		ifTrue: [^self selectedClass class]
		ifFalse: [^self selectedClass]