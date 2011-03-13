hierarchy
	"Retrieve a description of the superclass chain and subclasses of the 
	selected class."

	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	self messageCategoryListIndex: 0.
	editSelection _ #hierarchy.
	self changed: #editComment