removeAll: msgIDList fromCategory: categoryName
	"Remove all the messages with ID's in the given list from the given category."

	msgIDList do:
		[: msgID |
		 categoriesFile remove: msgID fromCategory: categoryName].