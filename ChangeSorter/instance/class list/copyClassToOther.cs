copyClassToOther
	"Place these changes in the other changeSet also"

	| otherSorter otherChangeSet |
	self checkThatSidesDiffer: [^ self].
	self okToChange ifFalse: [^ self beep].
	currentClassName ifNil: [^ self beep].
	otherSorter _ parent other: self.
	otherChangeSet _ otherSorter changeSet.

	otherChangeSet absorbClass: self selectedClassOrMetaClass name from: myChangeSet.
	otherSorter showChangeSet: otherChangeSet.