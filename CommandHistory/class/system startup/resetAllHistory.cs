resetAllHistory
	"Reset all command histories, and make all morphs that might be holding on to undo-grab-commands forget them"

	self allInstancesDo: [:c | c resetCommandHistory].
	self forgetAllGrabCommandsFrom: self someObject.

	"CommandHistory resetAllHistory"
