setSwitchState: aBoolean

	switchState _ aBoolean.
	disabled ifFalse:
		[switchState
			ifTrue:
				[self borderColor: #inset.
				self color: onColor]
			ifFalse:
				[self borderColor: #raised.
				self color: offColor]]