browseFullForClass: aClass method: aSelector
	"Create and schedule a full Browser and then select the class of the master object being inspected.  1/12/96 sw"

	Browser postOpenSuggestion: (Array with: aClass with: aSelector).
		"This takes effect after the Browser comes up"
	self openBrowser