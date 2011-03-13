plugMouseMoveToModel
	mouseMoveSelector _ (self knownName , 'MouseMove:event:') asSymbol.
	model class compile: (

'&nameMouseMove: location event: event
	"A mouseMove event has occurred.
	Add code to handle it here below..."'

			copyReplaceAll: '&name' with: self knownName)
		classified: 'input events' notifying: nil