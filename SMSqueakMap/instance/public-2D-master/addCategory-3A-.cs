addCategory: aCategory
	"Add a new category.
	Log it in the logfile."

	self log: aCategory.
	^categories at: aCategory id put: aCategory