mtdfSearch: theBoard score: estimate depth: depth 
	"An implementation of the MTD(f) algorithm. See:
		http://www.cs.vu.nl/~aske/mtdf.html
	"

	| beta move value low high goodMove |
	value := estimate.
	low := AlphaBetaMinVal.
	high := AlphaBetaMaxVal.
	[low >= high] whileFalse: 
			[beta := value = low ifTrue: [value + 1] ifFalse: [beta := value].
			move := self 
						searchMove: theBoard
						depth: depth
						alpha: beta - 1
						beta: beta.
			stopThinking ifTrue: [^move].
			move ifNil: [^move].
			value := move value.
			value < beta 
				ifTrue: [high := value]
				ifFalse: 
					["NOTE: It is important that we do *NOT* return a move from a search which didn't reach the beta goal (e.g., value < beta). This is because all it means is that we didn't reach beta and the move returned is not the move 'closest' to beta but just one that triggered cut-off. In other words, if we'd take a move which value is less than beta it could mean that this move is a *LOT* worse than beta."

					low := value.
					goodMove := move.
					activeVariation 
						replaceFrom: 1
						to: activeVariation size
						with: (variations first)
						startingAt: 1]].
	^goodMove