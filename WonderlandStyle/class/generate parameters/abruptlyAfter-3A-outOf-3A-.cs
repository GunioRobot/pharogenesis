abruptlyAfter: elapsed outOf: duration
	"Returns the proportion done for an Abrupt animation style after elapsed seconds (out of duration seconds) have elapsed."

	(elapsed >= duration) ifTrue: [ ^ 1.0 ].

	^ (elapsed / duration).
