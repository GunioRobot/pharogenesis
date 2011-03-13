addHaloControlsTo: controlPage
	"Add special controls relating to halo schemes to the page"

	| aButton |
	controlPage addTransparentSpacerOfSize: (0 @ 4).
	controlPage addMorphBack: self haloThemeRadioButtons.
	controlPage addTransparentSpacerOfSize: (0 @ 4).
	aButton _ SimpleButtonMorph new target: self; color: Color transparent; actionSelector: #editCustomHalos; label: 'Edit custom halos'.
	controlPage addMorphBack: aButton.
	aButton setBalloonText: 'Click here to edit the method that defines the custom halos'.
			