categoryContributions
	"Answer a list of arrays which characterize the elements in various viewer categories for the etoy system.  Implementors of this method are statically polled to contribute this information when the scripting system reinitializes its scripting info, which typically only happens after a structural change.

	Each array returned has two elements.  The first is the category name, and the second is a an array of <elementType> <elementName> pairs, where <elementType is #slot or #script"

	^ #(
		('playfield' ((script initiatePainting) (slot mouseX) (slot mouseY) (script roundUpStrays) (slot cursor) (slot valueAtCursor) (script unhideHiddenObjects)))

		('animation' ((slot cursor) (slot valueAtCursor)))

		('card/stack' ((script goToNextCard) (script goToPreviousCard) (script deleteCard) (script newCard)))

		('pen trails' ((script liftAllPens) (script lowerAllPens) (script clearTurtleTrails))))
