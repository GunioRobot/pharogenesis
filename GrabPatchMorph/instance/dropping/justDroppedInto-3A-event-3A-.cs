justDroppedInto: aPasteUpMorph event: anEvent
	"This message is sent to a dropped morph after it has been dropped on--and been accepted by--a drop-sensitive morph"

	aPasteUpMorph isPartsBin ifFalse:
		[self delete.
		ActiveWorld displayWorldSafely; runStepMethods.  "But the HW cursor stays up still ???"
		^ aPasteUpMorph grabDrawingFromScreen: anEvent].
	^ super justDroppedInto: aPasteUpMorph event: anEvent