allScriptVersionsDo: aBlock
	self isTextuallyCoded ifFalse: [aBlock value: currentScriptEditor].
	formerScriptEditors ifNotNil: [formerScriptEditors do:
		[:ed | aBlock value: ed]]