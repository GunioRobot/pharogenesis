removeCategoriesMatching: matchString
	"Remove all matching categories with their classes"
	(self categories select: [:c | matchString match: c]) do:
		[:c | self removeSystemCategory: c]