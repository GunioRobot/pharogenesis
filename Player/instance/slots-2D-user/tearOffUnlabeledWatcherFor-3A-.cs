tearOffUnlabeledWatcherFor: aGetter
	"Hand the user anUnlabeled readout for viewing a numeric value"

	| readout aWrapper |
	readout _ self unlabeledWatcherFor: aGetter.
	aWrapper _ WatcherWrapper new.
	aWrapper player: self variableName: (Utilities inherentSelectorForGetter: aGetter).
	aWrapper addMorphBack: readout.
	readout setNameTo: 'readout'.  "The wrapper bears the name for the user"
	aWrapper openInHand