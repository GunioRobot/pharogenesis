classify
	| count |
	self triangulation faces do: [:triangle |
		count _ triangle borderEdges size.
		count = 0 ifTrue: [triangle type: #junction].
		count = 1 ifTrue: [triangle type: #sleeve].
		count = 2 ifTrue: [triangle type: #terminal]]
		