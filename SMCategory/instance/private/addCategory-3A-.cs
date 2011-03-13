addCategory: cat
	"Add a category as a subcategory to self.
	The collection of subcategories is lazily instantiated."

	subCategories ifNil: [subCategories := OrderedCollection new].
	cat parent ifNotNil: [cat parent removeCategory: cat ].
	subCategories add: cat.
	cat parent: self.
	^cat