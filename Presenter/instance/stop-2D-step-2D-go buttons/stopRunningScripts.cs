stopRunningScripts
	self stopButtonState: true.
	self stepButtonState: false.
	self goButtonState: false.
	associatedMorph stopRunningAll.
	associatedMorph borderColor: Preferences borderColorWhenStopped