nodeCount
	"Answer the number of nodes in this parseTree (a rough measure of its size)."

	| cnt |
	cnt _ 0.
	self nodesDo: [ :n | cnt _ cnt + 1 ].
	^cnt