acceptOnFocusChange: aBoolean
	"Set whether the editor accepts its contents when it loses the keyboard focus."

	self setProperty: #acceptOnFocusChange toValue: aBoolean.
	self textMorph ifNotNilDo: [:t | t acceptOnFocusChange: aBoolean]