nodeForItem: item inMorph: pluggableListMorph
	^ children 
		detect: [:child | child displayString = item contents asString]
		ifNone: [item contents]