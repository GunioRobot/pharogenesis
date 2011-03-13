acceptDroppingMorph: aMorph event: evt

	target rememberUndoableAction:
			[target inAutoMove ifFalse: [target removeProperty: #stateBeforeGrab].
			self addMorph: aMorph.
			aMorph hasSubmorphs ifTrue:
				["Just dropped a sub-deck of cards"
				aMorph submorphs reverseDo: [:m | self addMorphFront: m]].
			(target ~~ nil and: [cardDroppedSelector ~~ nil])
				ifTrue: [target perform: cardDroppedSelector]]
		named: 'move card'