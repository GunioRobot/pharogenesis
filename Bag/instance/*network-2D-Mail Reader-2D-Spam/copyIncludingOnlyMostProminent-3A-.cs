copyIncludingOnlyMostProminent: numberToKeep

	| newBag numberToCopy sorted |
	sorted _ self orderedCounts.
	newBag := self species new.
	numberToCopy := numberToKeep min: sorted size.
	1 to: numberToCopy do: [:idx |
		| assoc |
		assoc := sorted at: idx.
		newBag add: assoc value withOccurrences: assoc key
	].
	^newBag