showMethodsWithInitials: initials
	"Make the current query be for methods stamped with the given initials"

	currentQuery _ #methodsWithInitials.
	currentQueryParameter _ initials.
	self showQueryResultsCategory.
	autoSelectString _ nil.
	self changed: #messageList.
	self adjustWindowTitle
