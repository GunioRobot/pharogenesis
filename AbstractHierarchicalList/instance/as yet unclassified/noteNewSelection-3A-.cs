noteNewSelection: x

	currentSelection _ x.
	self changed: #getCurrentSelection.
	currentSelection ifNil: [^self].
	currentSelection sendSettingMessageTo: self.
