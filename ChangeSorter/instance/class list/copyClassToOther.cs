copyClassToOther
	"Place these changes in the other changeSet also"

	| otherSorter otherChangeSet |
	self checkThatSidesDiffer: [^ self].
	self okToChange ifFalse: [^ Beeper beep].
	currentClassName ifNil: [^ Beeper beep].
	otherSorter _ parent other: self.
	otherChangeSet _ otherSorter changeSet.

	otherChangeSet absorbClass: self selectedClassOrMetaClass name from: myChangeSet.
	otherSorter showChangeSet: otherChangeSet.