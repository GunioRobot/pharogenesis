addControlsTab
	| controlPage |
	controlPage _ AlignmentMorph newColumn beSticky color: Color white.

	controlPage addMorphBack:
		(Preferences buttonRepresenting: #balloonHelpEnabled wording: 'Balloon Help' color: nil).

	controlPage addMorphBack:
		(Preferences buttonRepresenting: #fenceEnabled wording: 'Fence Enabled' color: nil).

	controlPage addMorphBack:
		(Preferences buttonRepresenting: #soundsEnabled wording: 'Sound Enabled' color: nil).

	controlPage setNameTo: 'controls'.
	self addTabForBook: controlPage  withBalloonText:
'controls to turn sound,
balloon help, etc., on and off'