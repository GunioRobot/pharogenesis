selectedClassOrMetaClass
	"Answer the selected class/trait or metaclass/classTrait."

	| cls |
	^self metaClassIndicated
		ifTrue: [(cls _ self selectedClass) ifNil: [nil] ifNotNil: [cls classSide]]
		ifFalse: [self selectedClass]