newFilterEntry
	"Answer a new filter entry field."

	^self
		newAutoAcceptTextEntryFor: self
		getText: #prefixFilter
		setText: #prefixFilter:
		getEnabled: nil
		help: 'Filters the options according to a prefix' translated