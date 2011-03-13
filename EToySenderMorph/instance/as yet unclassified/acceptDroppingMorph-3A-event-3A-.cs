acceptDroppingMorph: morphToDrop event: evt

	| myCopy outData |

	(morphToDrop isKindOf: NewHandleMorph) ifTrue: [			"don't send these"
		^morphToDrop rejectDropMorphEvent: evt.
	].
	self eToyRejectDropMorph: morphToDrop event: evt.		"we don't really want it"
	myCopy _ morphToDrop veryDeepCopy.	"gradient fills require doing this second"
	myCopy setProperty: #positionInOriginatingWorld toValue: morphToDrop position.
	self stopFlashing.

	outData _ myCopy eToyStreamedRepresentationNotifying: self.
	self resetIndicator: #working.
	self transmitStreamedObject: outData to: self ipAddress.

