reformulateList
	"Make the category list afresh, and reselect the current selector if appropriate"

	self preserveSelectorIfPossibleSurrounding:
		[super reformulateList.
		self categoryListIndex: categoryListIndex]