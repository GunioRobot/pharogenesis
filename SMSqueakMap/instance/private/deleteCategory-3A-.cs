deleteCategory: cat
	"Delete a category. Remove it and all its subCategories
	from all objects. Remove the category from its parent.
	Finally remove them all from my collections."

	cat removeDeepFromObjects.
	cat removeFromParent.
	cat allCategoriesDo: [:c |
		categories removeKey: c id ].
	^cat
