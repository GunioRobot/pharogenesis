knownTextStyles   "Utilities knownTextStyles"
	^ (TextConstants select: [:thang | thang isKindOf: TextStyle]) keys asSortedArray

