containingWindow
	"Answer the window that holds the receiver.  The dependents technique is odious and may not be airtight, if multiple windows have the same model."

	^ self dependents detect:
		[:d | ((d isKindOf: SystemWindow orOf: StandardSystemView) or: [d isKindOf: MVCWiWPasteUpMorph]) and: [d model == self]] ifNone: [nil]