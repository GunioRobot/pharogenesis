changeCategoriesTo: newCategories inObject: object
	"Remove or add categories in an object such that
	it belongs to the categories in <newCategories>.
	Logs the changes."

	newCategories do: [:cat |
		(object hasCategory: cat)
			ifFalse:[self addCategory: cat inObject: object]].
	object categories do: [:cat |
		(newCategories includes: cat)
			ifFalse: [self removeCategory: cat inObject: object]]
