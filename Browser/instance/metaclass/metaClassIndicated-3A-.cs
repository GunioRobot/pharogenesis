metaClassIndicated: trueOrFalse 
	"Indicate whether browsing instance or class messages."

	metaClassIndicated _ trueOrFalse.
	self setClassOrganizer.
	systemCategoryListIndex > 0 ifTrue:
		[self editSelection: (classListIndex = 0
			ifTrue: [metaClassIndicated
				ifTrue: [#none]
				ifFalse: [#newClass]]
			ifFalse: [#editClass])].
	messageCategoryListIndex _ 0.
	messageListIndex _ 0.
	contents _ nil.
	self changed: #classSelectionChanged.
	self changed: #messageCategoryList.
	self changed: #messageList.
	self changed: #contents.
	self changed: #annotation.
	self decorateButtons
