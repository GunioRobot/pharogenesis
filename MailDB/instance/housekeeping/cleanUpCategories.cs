cleanUpCategories
	"Prune the dead wood out of all categories."

	categoriesFile categories do:
		[: category |
		 categoriesFile removeMessagesInCategory: category butNotIn: indexFile].