editComment
	"Retrieve the description of the class comment."

	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	self messageCategoryListIndex: 0.
	editSelection _ #editComment.
	self changed: #classSelectionChanged.
	self changed: #contents.
