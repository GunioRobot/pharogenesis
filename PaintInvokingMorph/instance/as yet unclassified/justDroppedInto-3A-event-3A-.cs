justDroppedInto: aPasteUpMorph event: anEvent
	"This message is sent to a dropped morph after it has been dropped on--and been accepted by--a drop-sensitive morph"
	self isPartsDonor ifFalse: [^ self].
	(aPasteUpMorph isPlayfieldLike not or:
		[aPasteUpMorph isPartsBin]) ifTrue: [self beep.  self delete.  ^ self].
	self delete.
	anEvent hand makeNewDrawingInBounds: (aPasteUpMorph paintingBoundsAround: anEvent cursorPoint) pasteUpMorph: aPasteUpMorph