browseFullProtocol
	"Open up a protocol-category browser on the value of the receiver's current selection.  If in mvc, an old-style protocol browser is opened instead."

	| objectToRepresent |
	Smalltalk isMorphic ifFalse: [^ self spawnProtocol].

	objectToRepresent _ self selectionIndex == 0 ifTrue: [object] ifFalse: [self selection].
	InstanceBrowser new openOnObject: objectToRepresent inWorld: ActiveWorld showingSelector: nil