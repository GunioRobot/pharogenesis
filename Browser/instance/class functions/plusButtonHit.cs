plusButtonHit
	"Cycle among definition, comment, and hierachy"

	editSelection == #editComment
		ifTrue: [self hierarchy. ^ self].
	editSelection == #hierarchy
		ifTrue: [editSelection := #editClass.
			classListIndex = 0 ifTrue: [^ self].
			self okToChange ifFalse: [^ self].
			self changed: #editComment.
			self contentsChanged.
			^self].
	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	self messageCategoryListIndex: 0.
	editSelection := #editComment.
	self changed: #classSelectionChanged.
	self decorateButtons.
	self contentsChanged.