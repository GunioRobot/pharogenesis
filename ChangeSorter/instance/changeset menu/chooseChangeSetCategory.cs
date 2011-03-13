chooseChangeSetCategory
	"Present the user with a list of change-set-categories and let her choose one"
	self okToChange ifFalse: [^ self].
	^ self chooseChangeSetCategoryInMorphic
