addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add morph-specific items to the given menu which was invoked by the given hand."

	aCustomMenu add: 'add drop-shadow' action: #addDropShadow.
	(self isKindOf: SystemWindow)
		ifFalse: [aCustomMenu add: 'put in a window' action: #embedInWindow].
	aCustomMenu addUpdating: #stickinessString target: self action: #toggleStickiness.
	aCustomMenu add: 'adhere to edge...' action: #adhereToEdge.
	Preferences noviceMode ifFalse:
		[self addDebuggingItemsTo: aCustomMenu hand: aHandMorph].
