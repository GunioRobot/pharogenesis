makeNewSubclass

	self selectedClassOrMetaClass ifNil: [^ self].
	self okToChange ifFalse: [^ self].
	self editSelection: #newClass.
	self contentsChanged