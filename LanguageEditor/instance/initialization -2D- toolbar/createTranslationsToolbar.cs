createTranslationsToolbar
	"create a toolbar for the receiver"
	| toolbar |
	toolbar := self createRow.
	""
	toolbar
		addMorphBack: (self
				createUpdatingButtonWording: #translationsFilterWording
				action: #filterTranslations
				help: 'Filter the translations list.').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	""
	toolbar
		addMorphBack: (self
				createButtonLabel: 'search'
				action: #searchTranslation
				help: 'Search for a translation containing...').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'remove'
				action: #removeTranslation
				help: 'Remove the selected translation.  If none is selected, ask for the one to remove.').
	""
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'where'
				action: #browseMethodsWithTranslation
				help: 'Launch a browser on all methods that contain the phrase as a substring of any literal String.').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'r-unused'
				action: #removeTranslatedButUnusedStrings
				help: 'Remove all the strings that are not used by the system').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'add '
				action: #addTranslation
				help: 'Add a new phrase').

	^ toolbar