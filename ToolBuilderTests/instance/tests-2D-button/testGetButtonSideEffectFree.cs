testGetButtonSideEffectFree
	self makeButton.
	queries := IdentitySet new.
	self changed: #testSignalWithNoDiscernableEffect.
	self assert: queries isEmpty.