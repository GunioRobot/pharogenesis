requiredCategory: catName
	"catName is a required category.  If it does not exist in the database, then create it, and update the category list to reflect that it now exists."

	(self categoryList includes: catName)
		ifFalse:
			[mailDB addCategory: catName.
			self changed: #categoryList.]

