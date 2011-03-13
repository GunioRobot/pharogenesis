select: aBlock
	| result |
	result _ self species new: self capacity.
	self do: [:each | (aBlock value: each) ifTrue: [result add: each]].
	^ result.