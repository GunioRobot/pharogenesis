removeCategory: cat
	"Remove a category from subcategories of self.
	No error handling is done here."

	cat parent: nil.
	^subCategories remove: cat