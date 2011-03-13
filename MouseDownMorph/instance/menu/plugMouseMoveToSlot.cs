plugMouseMoveToSlot
	| varName |
	mouseMoveSelector _ (self knownName , 'MouseMove:event:') asSymbol.
	varName _ self knownName , 'MouseMove'.
	model class addSlotNamed: varName.
	model class compile: (

'&name: location event: event
	"A mouseMove event has occurred.
	Add code to handle it here below..."
	&name _ location.'

			copyReplaceAll: '&name' with: varName)
		classified: 'input events' notifying: nil