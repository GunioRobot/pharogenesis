classListIndex: anInteger 
	"Set anInteger to be the index of the current class selection."

	| className |
	classListIndex _ anInteger.
	self setClassOrganizer.
	messageCategoryListIndex _ 0.
	messageListIndex _ 0.
	self classCommentIndicated
		ifTrue: []
		ifFalse: [editSelection _ anInteger = 0
					ifTrue: [metaClassIndicated | (systemCategoryListIndex == 0)
						ifTrue: [#none]
						ifFalse: [#newClass]]
					ifFalse: [#editClass]].
	contents _ nil.
	self selectedClass isNil
		ifFalse: [className _ self selectedClass name.
					(RecentClasses includes: className)
				ifTrue: [RecentClasses remove: className].
			RecentClasses addFirst: className.
			RecentClasses size > 16
				ifTrue: [RecentClasses removeLast]].
	self changed: #classSelectionChanged.
	self changed: #classListIndex.	"update my selection"
	self changed: #messageCategoryList.
	self changed: #messageList.
	self contentsChanged