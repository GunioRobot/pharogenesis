disabled: aBoolean

	disabled _ aBoolean.
	disabled
		ifTrue:
			[self color: owner color.
			self borderColor: owner color]
		ifFalse:
			[self setSwitchState: self switchState]