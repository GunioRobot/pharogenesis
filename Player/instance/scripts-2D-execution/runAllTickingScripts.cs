runAllTickingScripts

	self instantiatedUserScriptsDo: [:aScriptInstantiation | aScriptInstantiation runIfTicking]