editClass
	"Retrieve the description of the class definition."

	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	self messageCategoryListIndex: 0.
	editSelection _ #editClass.
	self changed: #editClass