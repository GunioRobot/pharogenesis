newClass
	(self selectedClassOrMetaClass notNil and: 
		[self selectedClassOrMetaClass isTrait]) ifTrue: [self classListIndex: 0].
	self editClass.
	editSelection _ #newClass.
	self contentsChanged