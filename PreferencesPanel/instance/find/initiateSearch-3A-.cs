initiateSearch: morphHoldingSearchString
	"Carry out the action of the Search button in the Preferences panel"

	searchString _ morphHoldingSearchString text.
	self setSearchStringTo: self searchString.
	
	self findPreferencesMatchingSearchString