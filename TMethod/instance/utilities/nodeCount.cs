nodeCount
	"Answer the number of nodes in this method's parseTree (a rough measure of its size)."

	| cnt |
	cnt _ 0.
	parseTree nodesDo: [ :n | cnt _ cnt + 1 ].
	^cnt