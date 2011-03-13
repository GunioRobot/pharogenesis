systemCategoryListIndex: anInteger 
	"Set the selected system category index to be anInteger. Update all other 
	selections to be deselected."

	systemCategoryListIndex _ anInteger.
	classListIndex _ 0.
	messageCategoryListIndex _ 0.
	messageListIndex _ 0.
	editSelection _ 
		anInteger = 0
				ifTrue: [#none]
				ifFalse: [#newClass].
	metaClassIndicated _ false.
	self setClassOrganizer.
	contents _ nil.
	self changed: #systemCategorySelectionChanged