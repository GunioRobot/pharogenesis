filterBrowserMenu: menu
	self selectedActiveFilterIndex  > 0 ifTrue: [
		"add items for manipulating a filter"
		menu add: 'modify this filter' action: #editSelectedFilter.
		menu add: 'remove this filter' action: #removeSelectedFilter.
		menu add: 'save this filter' action: #saveCurrentFilter.

		(self isNamedFilter: self selectedActiveFilter) ifTrue: [
			menu add: 'destroy this named filter' action: #destroyCurrentFilter ].
		menu addLine ].

	menu add: 'add category filter' action: #addCategoryFilter.
	menu add: 'add participant filter' action: #addParticipantFilter.
	menu add: 'add subject filter' action: #addSubjectFilter.
	menu add: 'add code filter' action: #addCodeFilter.
	menu add: 'add named filter ->' action: #addNamedFilter.

	menu addLine.
	self addGeneralMenuOptionsTo: menu.

	^menu
	