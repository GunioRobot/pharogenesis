showMethodsInCurrentChangeSet
	"Set the current query to be for methods in the current change set"

	currentQuery _ #currentChangeSet.
	autoSelectString _ nil.
	self categoryListIndex: (categoryList indexOf: self class queryCategoryName).