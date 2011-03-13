mouseDown: evt
	(owner wantsKeyboardFocusFor: self) ifTrue:
		[putSelector ifNotNil: [
			minimumWidth _ (49 max: minimumWidth).	"leave space for editing"
			self launchMiniEditor: evt]]