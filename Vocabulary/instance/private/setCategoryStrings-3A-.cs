setCategoryStrings: categoryTriplets
	"Establish the category strings as per (internalCategorySymbol newCategoryWording balloon-help)"

	| category |
	categoryTriplets do:
		[:triplet |
			(category := self categoryAt: triplet first) ifNotNil: [
				category wording: triplet second.
				category helpMessage: triplet third]]