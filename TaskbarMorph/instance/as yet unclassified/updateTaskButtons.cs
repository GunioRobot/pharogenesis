updateTaskButtons
	"Make buttons for the ordered tasks."
	
	|button oldButtons|
	oldButtons := self submorphs copy.
	self removeAllMorphs.
	WorldState addDeferredUIMessage: [oldButtons do: [:b | b model: nil]]. "release dependency after event handling"
	self orderedTasks do: [:t |
		button := t taskbarButtonFor: self.
		button ifNotNil: [self addMorphBack: button]]