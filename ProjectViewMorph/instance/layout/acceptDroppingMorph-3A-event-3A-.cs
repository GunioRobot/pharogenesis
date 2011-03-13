acceptDroppingMorph: morphToDrop event: evt

	| myCopy smallR |

	(self isTheRealProjectPresent) ifFalse: [
		^morphToDrop rejectDropMorphEvent: evt.		"can't handle it right now"
	].
	(morphToDrop isKindOf: NewHandleMorph) ifTrue: [	"don't send these"
		^morphToDrop rejectDropMorphEvent: evt.
	].
	myCopy := morphToDrop veryDeepCopy.	"gradient fills require doing this second"
	smallR := (morphToDrop bounds scaleBy: image height / Display height) rounded.
	smallR := smallR squishedWithin: image boundingBox.
	image getCanvas
		paintImage: (morphToDrop imageForm scaledToSize: smallR extent)
		at: smallR topLeft.
	myCopy openInWorld: project world

