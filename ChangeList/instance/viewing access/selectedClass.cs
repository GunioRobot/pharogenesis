selectedClass
	^(self selectedClassOrMetaClass ifNil: [ ^nil ]) theNonMetaClass 