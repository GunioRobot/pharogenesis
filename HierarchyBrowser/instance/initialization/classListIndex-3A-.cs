classListIndex: newIndex
	"Cause system organization to reflect appropriate category"
	| newClassName ind |
	newIndex ~= 0 ifTrue:
		[newClassName _ (classList at: newIndex) copyWithout: $ .
		systemCategoryListIndex _
			systemOrganizer numberOfCategoryOfElement: newClassName].
	ind _ super classListIndex: newIndex.
	self changed: #systemCategorySingleton.
	^ ind