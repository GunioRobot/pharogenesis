openFactoredPanelWithWidth: aWidth 
	"Open up a preferences panel of the given width"

	"Preferences openFactoredPanelWithWidth: 325"
	| window playfield aPanel |

	aPanel _ PreferencesPanel new.
	playfield _ PasteUpMorph new width: aWidth.
	playfield dropEnabled: false.
	self initializePreferencePanel: aPanel in: playfield.
	self couldOpenInMorphic
		ifTrue: [window _ (SystemWindow labelled: 'Preferences')
						model: aPanel.
			window on: #keyStroke send: #keyStroke: to: aPanel.
			window
				bounds: (100 @ 100 - (0 @ window labelHeight + window borderWidth) extent: playfield extent + (2 * window borderWidth)).
			window
				addMorph: playfield
				frame: (0 @ 0 extent: 1 @ 1).
			window updatePaneColors.
			window setProperty: #minimumExtent toValue: playfield extent + (12@15).
			self currentWorld addMorphFront: window.
			window center: self currentWorld center.
			window activateAndForceLabelToShow]
		ifFalse:
			[(window _ MVCWiWPasteUpMorph newWorldForProject: nil) addMorph: playfield.
			MorphWorldView
				openOn: window
				label: 'Preferences'
				extent: playfield extent]