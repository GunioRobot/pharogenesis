openOn: aFileName
	| newMe |
	newMe := self new.
	newMe createWindow; fileName: aFileName; openInWorld.
	^newMe