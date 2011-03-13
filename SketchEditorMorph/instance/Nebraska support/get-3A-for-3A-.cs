get: aSymbol for: anEventOrHand

	| valuesForHand |

	valuesForHand _ self valuesForHand: anEventOrHand.
	^valuesForHand at: aSymbol ifAbsent: [nil].

