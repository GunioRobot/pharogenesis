acceptDroppingMorph: morphToDrop event: evt

	| myCopy outData null |

	(morphToDrop isKindOf: NewHandleMorph) ifTrue: [			"don't send these"
		^morphToDrop rejectDropMorphEvent: evt.
	].
	self eToyRejectDropMorph: morphToDrop event: evt.		"we don't really want it"

	"7 mar 2001 - remove #veryDeepCopy"
	myCopy _ morphToDrop.	"gradient fills require doing this second"
	myCopy setProperty: #positionInOriginatingWorld toValue: morphToDrop position.

	outData _ myCopy eToyStreamedRepresentationNotifying: nil.
	null _ String with: 0 asCharacter.
	EToyPeerToPeer new 
		sendSomeData: {
			EToyIncomingMessage typeMorph,null. 
			Preferences defaultAuthorName,null.
			outData
		}
		to: (NetNameResolver stringFromAddress: connection remoteAddress)
		for: self.
