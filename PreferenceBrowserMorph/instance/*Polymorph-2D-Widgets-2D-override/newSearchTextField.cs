newSearchTextField
	"Answer a new text entry for searching of preferences."
	
	^UITheme builder
		newAutoAcceptTextEntryFor: self model
		getText: #searchPattern
		setText: #searchPattern:
		getEnabled: nil
		help: 'Filters the preferences according to a prefix' translated