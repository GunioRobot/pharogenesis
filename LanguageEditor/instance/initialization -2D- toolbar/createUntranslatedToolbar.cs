createUntranslatedToolbar
	"create a toolbar for the receiver"
	| toolbar |
	toolbar := self createRow.
	""
	toolbar
		addMorphBack: (self
				createUpdatingButtonWording: #untranslatedFilterWording
				action: #filterUntranslated
				help: 'Filter the untranslated list.').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	""
	toolbar
		addMorphBack: (self
				createButtonLabel: 'search'
				action: #searchUntranslated
				help: 'Search for a untranslated phrase containing...').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'remove'
				action: #removeUntranslated
				help: 'Remove the selected untranslated phrease.  If none is selected, ask for the one to remove.').
	""
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'translate'
				action: #translate
				help: 'Translate the selected untranslated phrase or a new phrase').
	""
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'where'
				action: #browseMethodsWithUntranslated
				help: 'Launch a browser on all methods that contain the phrase as a substring of any literal String.').
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'r-unused'
				action: #removeUntranslatedButUnusedStrings
				help: 'Remove all the strings that are not used by the system').
	^ toolbar