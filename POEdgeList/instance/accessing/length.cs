length
	| total |
	total _ 0.
	self halfedges do: [:edge | total _ total + edge length].
	^ total / 2