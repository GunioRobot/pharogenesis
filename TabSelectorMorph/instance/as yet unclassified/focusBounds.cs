focusBounds
	"Answer the bounds for drawing the focus indication."

	^self selectedTab
		ifNil: [super focusBounds]
		ifNotNilDo: [:tab | tab focusBounds]