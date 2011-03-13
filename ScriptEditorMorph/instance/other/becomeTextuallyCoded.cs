becomeTextuallyCoded
	self isTextuallyCoded ifTrue: [^ self].
	self saveScriptVersion.
	self userScriptObject becomeTextuallyCoded.
	(submorphs copyFrom: 2 to: submorphs size) do: [:m | m delete].
	self color: Color darkGray