systemCategoryListIndex: anInteger 
	"Set the selected system category index to be anInteger. Update all other 
	selections to be deselected."

	systemCategoryListIndex _ anInteger.
	classListIndex _ 0.
	messageCategoryListIndex _ 0.
	messageListIndex _ 0.
	self editSelection: ( anInteger = 0 ifTrue: [#none] ifFalse: [#newClass]).
	metaClassIndicated _ false.
	self setClassOrganizer.
	contents _ nil.
	self changed: #systemCategorySelectionChanged.
	self changed: #systemCategoryListIndex.	"update my selection"
	self changed: #classList.
	self changed: #messageCategoryList.
	self changed: #messageList.
	self changed: #relabel.
	self contentsChanged