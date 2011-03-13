addCustomMenuItems: aCustomMenu hand: aHandMorph
	"Add morph-specific items to the given menu which was invoked by the given hand."

	aCustomMenu add: 'add drop-shadow' action: #addDropShadow.
	self isSticky
		ifTrue:
			[aCustomMenu add: 'stop being sticky' action: #toggleStickiness]
		ifFalse:
			[aCustomMenu add: 'start being sticky' action: #toggleStickiness].
