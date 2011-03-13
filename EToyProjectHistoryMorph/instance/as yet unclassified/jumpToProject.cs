jumpToProject

	| selection |
	selection _ (Project buildJumpToMenu: CustomMenu new) startUp.
	self closeMyFlapIfAny.
	Project jumpToSelection: selection
