newSearchPanel
	"Answer the panel for searching of preferences."
	
	^UITheme builder newRow: {
		UITheme builder newLabel: 'Search preferences for:' translated.
		self newSearchTextField}