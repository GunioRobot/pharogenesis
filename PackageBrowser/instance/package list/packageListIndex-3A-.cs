packageListIndex: anInteger 
	"Set anInteger to be the index of the current package selection."

	packageListIndex := anInteger.
	anInteger = 0
		ifFalse: [package := self packageList at: packageListIndex].
	messageCategoryListIndex := 0.
	systemCategoryListIndex := 0.
	messageListIndex := 0.
	classListIndex := 0.
	self setClassOrganizer.
	self changed: #packageSelectionChanged.
	self changed: #packageListIndex.	"update my selection"
	self changed: #systemCategoryList.	"update the category list"
	self systemCategoryListIndex: 0.	"update category list selection"
