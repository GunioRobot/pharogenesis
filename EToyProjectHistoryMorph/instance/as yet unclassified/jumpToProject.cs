jumpToProject

	| selection |
	selection := (Project buildJumpToMenu: CustomMenu new) startUp.
	self closeMyFlapIfAny.
	Project jumpToSelection: selection
