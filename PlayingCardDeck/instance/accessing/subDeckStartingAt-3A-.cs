subDeckStartingAt: aCard
	| i subDeck |

	i _ submorphs indexOf: aCard ifAbsent: [^ aCard].
	i = 1 ifTrue: [^aCard].
	subDeck _ PlayingCardDeck new.
	(submorphs copyFrom: 1 to: i-1) do:
			[:m | m class = aCard class ifTrue: [subDeck addMorphBack: m]].
	^subDeck.
	