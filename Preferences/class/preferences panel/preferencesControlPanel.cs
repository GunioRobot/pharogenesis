preferencesControlPanel
	"Answer a Preferences control panel window"

	"Preferences preferencesControlPanel openInHand"
	| window playfield aPanel |

	aPanel _ PreferencesPanel new.
	playfield _ PasteUpMorph new width: 325.
	playfield dropEnabled: false.
	window _ (SystemWindow labelled: 'Preferences') model: aPanel.
	self initializePreferencePanel: aPanel in: playfield.
	window on: #keyStroke send: #keyStroke: to: aPanel.
	window bounds: (100 @ 100 - (0 @ window labelHeight + window borderWidth) extent: playfield extent + (2 * window borderWidth)).
	window addMorph: playfield frame: (0 @ 0 extent: 1 @ 1).
	window updatePaneColors.
	window setProperty: #minimumExtent toValue: playfield extent + (12@15).
	^ window