removeAllButMostProminent: numberToKeep
	| sorted |
	sorted _ self sortedCounts.
	((sorted last: (sorted size - numberToKeep)) collect: [:a | a value]) do: [:e | self removeAllCopiesOf: e].
