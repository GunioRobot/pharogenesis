removeScript: aSymbol
	self removeScriptWithoutUpdatingViewers: aSymbol.
	self updateAllViewersAndForceToShow: 'scripts'
