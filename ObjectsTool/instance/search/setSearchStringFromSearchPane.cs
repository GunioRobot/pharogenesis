setSearchStringFromSearchPane
	"Set the search string by obtaining its contents from the search pane, and doing a certain amount of munging"

	searchString _ self searchPane text string asLowercase withBlanksTrimmed.
	searchString _ searchString copyWithoutAll: {Character enter. Character cr}