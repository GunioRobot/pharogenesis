addCustomMenuItems: menu hand: aHandMorph
	"Add morph-specific menu itemns to the menu for the hand"

	super addCustomMenuItems: menu hand: aHandMorph.
	self addStackMenuItems: menu hand: aHandMorph.
	self addPenMenuItems: menu hand: aHandMorph.
	self addPlayfieldMenuItems: menu hand: aHandMorph.

	self isWorldMorph ifTrue:
		[(owner isKindOf: BOBTransformationMorph) ifTrue:
			[self addScalingMenuItems: menu hand: aHandMorph].
		Flaps sharedFlapsAllowed ifTrue:
			[menu addUpdating: #suppressFlapsString
				target: CurrentProjectRefactoring 
				action: #currentToggleFlapsSuppressed].
		menu add: 'desktop menu...' translated target: self action: #putUpDesktopMenu:].

	menu addLine