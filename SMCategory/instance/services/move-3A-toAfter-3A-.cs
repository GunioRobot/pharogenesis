move: cat toAfter: before
	"Move a category to be after the category <before>."

	subCategories remove: cat.
	before ifNil: [subCategories addFirst: cat] ifNotNil: [subCategories add: cat after: before]