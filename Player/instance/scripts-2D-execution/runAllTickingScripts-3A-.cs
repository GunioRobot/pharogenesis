runAllTickingScripts: nowTick

	self instantiatedUserScriptsDo: [:aScriptInstantiation | aScriptInstantiation runIfTicking: nowTick]