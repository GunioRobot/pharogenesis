selectedMember
	^memberIndex
		ifNil: [ nil ]
		ifNotNil: [ self members at: memberIndex ifAbsent: [ ] ]