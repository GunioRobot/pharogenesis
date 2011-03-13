selectedClassOrMetaClass
	"Answer the selected class or metaclass."

	| cls |
	self metaClassIndicated
		ifTrue: [^ (cls _ self selectedClass) ifNil: [nil] ifNotNil: [cls class]]
		ifFalse: [^ self selectedClass]