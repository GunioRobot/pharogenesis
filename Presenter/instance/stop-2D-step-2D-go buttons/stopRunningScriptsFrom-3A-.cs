stopRunningScriptsFrom: aStopButton
	(stopButton == nil or: [stopButton isInWorld not]) ifTrue: [stopButton _ aStopButton].
	self stopButtonState: true.
	self stepButtonState: false.
	self goButtonState: false.
	associatedMorph stopRunningAll.
	associatedMorph borderColor: Preferences borderColorWhenStopped