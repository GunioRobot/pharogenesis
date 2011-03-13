handleDisabledKey: anEvent
	"Handle a key character when the text morph is disabled."
	
	super handleDisabledKey: anEvent.
	self storeSelectionInParagraph