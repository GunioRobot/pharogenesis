select: aBlock
	| result |
	result := self species new: self capacity.
	self do: [:each | (aBlock value: each) ifTrue: [result add: each]].
	^ result.