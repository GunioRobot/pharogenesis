addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Note minor loose end here -- if the menu is persistent, then the wording will be wrong half the time"
	| item |
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	item _ showSeconds == true
		ifTrue:	['stop showing seconds']
		ifFalse: ['start showing seconds'].
	aCustomMenu add: item translated target: self action: #toggleShowingSeconds.
	item _ show24hr == true
		ifTrue: ['display Am/Pm']
		ifFalse: ['display 24 hour'].
	aCustomMenu add: item translated target: self action: #toggleShowing24hr.	
		
