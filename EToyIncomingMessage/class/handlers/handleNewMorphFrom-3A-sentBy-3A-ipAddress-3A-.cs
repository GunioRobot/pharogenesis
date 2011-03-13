handleNewMorphFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	| newObject thumbForm targetWorld |

	newObject := self newObjectFromStream: dataStream.
	EToyCommunicatorMorph playArrivalSound.
	targetWorld := self currentWorld.
	(EToyMorphsWelcomeMorph morphsWelcomeInWorld: targetWorld) ifTrue: [
		newObject position: (
			newObject 
				valueOfProperty: #positionInOriginatingWorld 
				ifAbsent: [(targetWorld randomBoundsFor: newObject) topLeft]
		).
		WorldState addDeferredUIMessage: [
			newObject openInWorld: targetWorld.
		] fixTemps.
		^self
	].
	thumbForm := newObject imageForm scaledToSize: 50@50.
	EToyListenerMorph addToGlobalIncomingQueue: {
		thumbForm. newObject. senderName. ipAddressString
	}.
	WorldState addDeferredUIMessage: [
		EToyListenerMorph ensureListenerInCurrentWorld
	] fixTemps.
