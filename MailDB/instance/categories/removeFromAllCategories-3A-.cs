removeFromAllCategories: msgID
	"Remove the message with the given ID from all categories. The message will appear in 'unclassified'."

	categoriesFile categories do:
		[: categoryName |
		 categoriesFile remove: msgID fromCategory: categoryName].