repositionAnchoredMorphs

	| am cBlock leftShift firstCharacterIndex lastCharacterIndex |

	firstCharacterIndex _ self paragraph firstCharacterIndex.
	lastCharacterIndex _ paragraph lastCharacterIndex.
	text runs withStartStopAndValueDo: [:start :stop :attributes |
		attributes do: [:att |
			(att isMemberOf: TextAnchorPlus) ifTrue: [
				am _ att anchoredMorph.
				(am isNil or: [am world isNil]) ifFalse: [
					(stop between: firstCharacterIndex and: lastCharacterIndex) ifTrue: [
						cBlock _ self paragraph characterBlockForIndex: stop.
						leftShift _ am valueOfProperty: #geeMailLeftOffset ifAbsent: [0].
						am position: (self left + leftShift) @ cBlock origin y.
					].
				]
			]
		]
	].
