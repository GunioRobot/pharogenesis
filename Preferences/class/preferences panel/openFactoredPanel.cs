openFactoredPanel
	"Open up a tabbed Preferences panel.  In mvc, a new one is launched on each request; in Morphic, any existing one is opened, and a new one launched only if no existing one can be found."

	Smalltalk isMorphic
		ifTrue:  "reuse an existing one if one is found, else create a fresh one"
			[self currentWorld findAPreferencesPanel: nil] 

		ifFalse:  "in mvc, always opens a new one for now"
			[self openNewPreferencesPanel]

"Preferences openFactoredPanel"
