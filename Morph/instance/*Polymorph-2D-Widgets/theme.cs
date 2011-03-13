theme
	"Answer the current theme for the receiver."

	(self valueOfProperty: #theme) ifNotNilDo: [:t | ^ t].
	^(self window ifNil: [self class]) theme