cumulativeCounts
	"Answer with a collection of cumulative percents covered by elements so far."
	| s n |
	s _ self size // 100.0. n _ 0.
	^ self sortedCounts asArray collect:
		[:a | n _ n + a key. (n // s roundTo: 0.1) -> a value]