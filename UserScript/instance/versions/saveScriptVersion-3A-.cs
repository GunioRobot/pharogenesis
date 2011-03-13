saveScriptVersion: timeStampCurrentlyIgnored
	self isTextuallyCoded ifFalse:
		[formerScriptEditors == nil ifTrue: [formerScriptEditors _ OrderedCollection new].
		currentScriptEditor ifNotNil: [formerScriptEditors add: currentScriptEditor fullCopy].
		formerScriptEditors size > 100 ifTrue: [^ self halt: 'apparent runaway versions']]