toggleWhetherShowingOnlyTopControls
	"Toggle whether the receiver is showing only the stop/step/go line or the full whammy"

	| aCenter |
	showingOnlyTopControls _ self showingOnlyTopControls not.
	aCenter _ self center x.
	self showingOnlyTopControls
		ifTrue:
			[self removeAllButFirstSubmorph]
		ifFalse:
			[self addSecondLineOfControls.
			self presenter reinvigorateAllScriptsTool: self].
	WorldState addDeferredUIMessage:
		[self center: (aCenter @ self center y)]
	