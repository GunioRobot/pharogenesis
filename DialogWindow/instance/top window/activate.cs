activate
	"Set the default focus for now, will want to
	remember it at some point."
	
	super activate.
	self world ifNil: [^self].
	self rememberedKeyboardFocus
		ifNil: [self defaultFocusMorph ifNotNilDo: [:m |
				m takeKeyboardFocus]]