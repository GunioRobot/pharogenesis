mouseMove: evt 
	"Change the selection in response to moue-down drag"

	pivotBlock ifNil: [^ self].  "Patched during clickAt: repair"
	self pointBlock: (paragraph characterBlockAtPoint: (evt cursorPoint)).
	self storeSelectionInParagraph