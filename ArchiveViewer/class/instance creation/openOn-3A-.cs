openOn: aFileName
	| newMe |
	newMe _ self new.
	newMe createWindow; fileName: aFileName; openInWorld.
	^newMe