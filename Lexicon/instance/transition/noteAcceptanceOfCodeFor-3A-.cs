noteAcceptanceOfCodeFor: newSelector
	"The user has submitted new code for the given selector; take a note of it.  NB that the selectors-changed list gets added to here, but is not currently used in the system."

	(self selectorsVisited includes: newSelector) ifFalse: [selectorsVisited add: newSelector].