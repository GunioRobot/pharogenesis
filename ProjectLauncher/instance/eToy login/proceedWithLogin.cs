proceedWithLogin
	eToyAuthentificationServer _ nil.
	World submorphsDo:[:m| m show].
	WorldState addDeferredUIMessage: [self startUpAfterLogin].