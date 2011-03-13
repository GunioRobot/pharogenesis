addCustomMenuItems: aCustomMenu hand: aHandMorph
	| realOwner realMorph |
	"Add morph-specific items to the given menu which was invoked by the given hand.  Note the special-casing of Worlds, for which some of the the otherwise generic items are excluded."
	aCustomMenu addUpdating: #hasDragAndDropEnabledString action: #changeDragAndDrop.

	self isWorldMorph
		ifFalse:
			[(self isKindOf: SystemWindow)
				ifFalse: [aCustomMenu add: 'put in a window' action: #embedInWindow].
			aCustomMenu addUpdating: #stickinessString target: self action: #toggleStickiness.
			aCustomMenu add: 'adhere to edge...' action: #adhereToEdge]
		ifTrue:
			[aCustomMenu add: 'desktop menu...' target: self action: #putUpDesktopMenu:.
			aCustomMenu addLine].

	Preferences noviceMode ifFalse:
		[self addDebuggingItemsTo: aCustomMenu hand: aHandMorph].

	realOwner _ (realMorph _ self topRendererOrSelf) owner.
	(realOwner isKindOf: TextPlusPasteUpMorph) ifTrue:
		[aCustomMenu add: 'GeeMail stuff...' subMenu: (realOwner textPlusMenuFor: realMorph)]