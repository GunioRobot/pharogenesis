addCloseBox
	self addMorph: (closeBox _ SimpleButtonMorph new borderWidth: 0;
			label: 'X' font: Preferences standardButtonFont; color: Color transparent;
			actionSelector: #delete; target: self; extent: 14@14)