fileAll: msgIDList inCategory: categoryName
	"File all the messages with ID's in the given list in the given category."

	msgIDList do:
		[: msgID |
		 categoriesFile file: msgID inCategory: categoryName].