createMainToolbar
	"create a toolbar for the receiver"
	| toolbar |
	toolbar := self createRow.
	""
"	toolbar
		addMorphBack: (self
				createUpdatingButtonWording: #debugWording
				action: #switchDebug
				help: 'Switch the debug flag')."
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	""
	toolbar
		addMorphBack: (self
				createButtonLabel: 'save'
				action: #saveToFile
				help: 'Save the translations to a file').
	toolbar
		addMorphBack: (self
				createButtonLabel: 'load'
				action: #loadFromFile
				help: 'Load the translations from a file').
	toolbar
		addMorphBack: (self
				createButtonLabel: 'merge'
				action: #mergeFromFile
				help: 'Merge the current translations with the translations in a file').
	""
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'apply'
				action: #applyTranslations
				help: 'Apply the translations as much as possible.').
	""
	toolbar addTransparentSpacerOfSize: 5 @ 0.
	toolbar
		addMorphBack: (self
				createButtonLabel: 'check translations'
				action: #check
				help: 'Check the translations and report the results.').
	toolbar
		addMorphBack: (self
				createButtonLabel: 'report'
				action: #report
				help: 'Create a report.').
	toolbar
		addMorphBack: (self
				createButtonLabel: 'gettext export'
				action: #getTextExport
				help: 'Exports the translations in GetText format.').
	""
	^ toolbar