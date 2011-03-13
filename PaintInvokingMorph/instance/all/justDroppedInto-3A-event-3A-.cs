justDroppedInto: aPasteUpMorph event: anEvent
	"This message is sent to a dropped morph after it has been dropped on--and been accepted by--a drop-sensitive morph"

	aPasteUpMorph isPlayfieldLike ifFalse: [self beep.  ^ self].
	self delete.
	anEvent hand makeNewDrawingInBounds: (aPasteUpMorph paintingBoundsAround: anEvent cursorPoint) pasteUpMorph: aPasteUpMorph
