openTrash
	"User wants to see what is in the trash."

	| palette paintBox |
	"See if a stamp is being dropped into the trash. It is not held by the hand."
	(paintBox _ self findActivePaintBox) ifNotNil: [
		paintBox getSpecial == #stamp: ifTrue: [
			paintBox deleteCurrentStamp.  "throw away stamp..."
			self primaryHand showTemporaryCursor: nil.
			^ self]].	  "... and don't open trash"

	palette _ self world findA: EToyPalette.
	palette ifNotNil: [^ palette showTrashPalette].
