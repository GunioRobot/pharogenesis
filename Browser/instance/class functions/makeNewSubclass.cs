makeNewSubclass

	self selectedClassOrMetaClass ifNil: [^ self].
	self okToChange ifFalse: [^ self].
	editSelection _ #newClass.
	self contentsChanged