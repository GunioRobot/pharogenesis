classListIndex: newIndex
	"Cause system organization to reflect appropriate category"
	| newClassName |
	newIndex ~= 0 ifTrue:
		[newClassName _ (classList at: newIndex) copyWithout: $ .
		systemCategoryListIndex _
			systemOrganizer numberOfCategoryOfElement: newClassName.
		self changed: #systemCategorySelectionChanged].
	^ super classListIndex: newIndex