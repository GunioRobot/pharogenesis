setSearchStringTo: aText
	"The user submitted aText as the search string; now search for it"

	searchString _ aText asString.
	self findPreferencesMatching: searchString.
	^ true