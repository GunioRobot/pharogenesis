changeCategoriesTo: newCategories inCard: card
	"Remove or add categories in a card such that
	it belongs to the categories in <newCategories>.
	Logs the changes."

	newCategories do: [:cat |
		(card hasCategory: cat)
			ifFalse:[self addCategory: cat inCard: card]].
	card categories do: [:cat |
		(newCategories includes: cat)
			ifFalse: [self removeCategory: cat inCard: card]]
