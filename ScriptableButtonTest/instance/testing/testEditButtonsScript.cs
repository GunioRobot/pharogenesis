testEditButtonsScript
	self shouldnt: [button editButtonsScript] raise: Error.
	World currentHand submorphsReverseDo: [:each | each delete].
			