addYesNoToHand

	| ms messageNodeMorph |
	(self world valueOfProperty: #universalTiles ifAbsent: [false])
		ifTrue: [ms _ MessageSend receiver: true selector: #ifTrue:ifFalse: 
						arguments: {['do nothing']. ['do nothing']}.
			messageNodeMorph _ ms asTilesIn: playerScripted class.
			"messageNodeMorph setProperty: #whoIsSelf toValue: playerScripted."
			self primaryHand attachMorph: messageNodeMorph]
		ifFalse: [self primaryHand attachMorph: CompoundTileMorph new].