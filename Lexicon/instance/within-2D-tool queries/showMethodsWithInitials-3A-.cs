showMethodsWithInitials: initials
	"Make the current query be for methods stamped with the given initials"

	currentQuery := #methodsWithInitials.
	currentQueryParameter := initials.
	self showQueryResultsCategory.
	autoSelectString := nil.
	self changed: #messageList.
	self adjustWindowTitle
