useTemporaryHandDuring: aBlock

	| lastHand tmpHand w |

	w _ Display bestGuessOfCurrentWorld.
	w removeHand: (lastHand _ w activeHand).
	w addHand: (tmpHand _ lastHand copy).
	aBlock value: tmpHand.
	w removeHand: tmpHand.
	w addHand: lastHand.
