addCloseBox
	| frame |
	closeBox _ SimpleButtonMorph new borderWidth: 0;
			label: 'X' font: Preferences standardButtonFont; color: Color transparent;
			actionSelector: #closeBoxHit; target: self; extent: 14@14.
	frame _ LayoutFrame new.
	frame leftFraction: 0; leftOffset: 4; topFraction: 0; topOffset: 1.
	closeBox layoutFrame: frame.
	labelArea addMorph: closeBox.