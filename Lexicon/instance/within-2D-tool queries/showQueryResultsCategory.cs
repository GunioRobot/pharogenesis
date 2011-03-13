showQueryResultsCategory
	"Point the receiver at the query-results category and set the search string accordingly"

	autoSelectString := self currentQueryParameter.
	self categoryListIndex: (categoryList indexOf: self class queryCategoryName).
	self messageListIndex: 0