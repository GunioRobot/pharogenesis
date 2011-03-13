addYesNoToHand
	"Place a test/yes/no complex in the hand of the beloved user"

	| ms messageNodeMorph aMorph |
	Preferences universalTiles
		ifTrue:
			[ms _ MessageSend receiver: true selector: #ifTrue:ifFalse:
						arguments: {['do nothing']. ['do nothing']}.
			messageNodeMorph _ ms asTilesIn: playerScripted class globalNames: true.
			self primaryHand attachMorph: messageNodeMorph]
		ifFalse:
			[aMorph _ CompoundTileMorph new.
			ActiveHand attachMorph: aMorph.
			aMorph setNamePropertyTo: 'TestTile' translated.
			aMorph position: ActiveHand position.
			aMorph formerPosition: ActiveHand position.
			self startSteppingSelector: #trackDropZones.]