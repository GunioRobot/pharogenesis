mouseDown: evt

	disabled ifFalse:
		[oldSwitchState _ switchState.
		self setSwitchState: (oldSwitchState = false).
		self doButtonAction].
