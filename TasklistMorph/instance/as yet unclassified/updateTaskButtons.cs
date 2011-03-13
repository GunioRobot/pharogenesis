updateTaskButtons
	"Make buttons for the ordered tasks."
	
	|button|
	self taskList removeAllMorphs.
	self tasks do: [:t |
		button := t tasklistButtonFor: self.
		button ifNotNil: [self taskList addMorphBack: button]]