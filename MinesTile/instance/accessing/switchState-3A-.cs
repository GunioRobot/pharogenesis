switchState: aBoolean

	switchState _ aBoolean.
	disabled ifFalse:
		[switchState
			ifTrue:[
				"flag ifTrue: [self setFlag]." "if this is a flagged tile, unflag it."
				self borderColor: #inset.
				self color: onColor]
			ifFalse:[
				self borderColor: #raised.
				self color: offColor]]