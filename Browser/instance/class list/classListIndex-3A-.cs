classListIndex: anInteger 
	"Set anInteger to be the index of the current class selection."
	classListIndex _ anInteger.
	self setClassOrganizer.
	messageCategoryListIndex _ 0.
	messageListIndex _ 0.
	editSelection _ anInteger = 0
			ifTrue: [metaClassIndicated
				ifTrue: [#none]
				ifFalse: [#newClass]]
			ifFalse: [#editClass].
	contents _ nil.
	self changed: #classSelectionChanged