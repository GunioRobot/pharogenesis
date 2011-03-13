setSwitchState: aBoolean

	aBoolean
		ifTrue: [
			self borderColor: #inset.
			self color: onColor]
		ifFalse: [
			self borderColor: #raised.
			self color: offColor].
