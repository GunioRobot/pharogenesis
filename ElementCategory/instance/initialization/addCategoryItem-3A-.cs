addCategoryItem: anItem
	"Add the item at the end, obtaining its key from itself (it must respond to #categoryName)"

	self elementAt: anItem categoryName put: anItem