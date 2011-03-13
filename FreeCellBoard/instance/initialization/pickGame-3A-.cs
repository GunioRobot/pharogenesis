pickGame: aSeedOrNil
	| sorted msg |
	cardDeck _ PlayingCardDeck newDeck.
	aSeedOrNil == 1
	ifTrue:
		["Special case of game 1 does a time profile playing the entire (trivial) game."
		sorted _ cardDeck submorphs asSortedCollection: [ :a :b | a cardNumber >= b cardNumber].
		cardDeck
			removeAllMorphs;
			addAllMorphs: sorted.
		self resetBoard.
		self world doOneCycle.
		Utilities informUser: 'Game #1 is a special case
for performance analysis' during:
			[msg _ self world firstSubmorph.
			msg align: msg topRight with: owner bottomRight.
			MessageTally spyOn: [sorted last owner doubleClickOnCard: sorted last]]]
	ifFalse:
		[aSeedOrNil ifNotNil:[cardDeck seed: aSeedOrNil].
		cardDeck shuffle.
		self resetBoard].
	