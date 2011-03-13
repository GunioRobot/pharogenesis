wantsYellowButtonMenu
	"Answer true if the receiver wants a yellow button menu.
	Fixed for when generalizedYellowButtonMenu pref is off"
	
	^Preferences noviceMode not and: [Preferences generalizedYellowButtonMenu]