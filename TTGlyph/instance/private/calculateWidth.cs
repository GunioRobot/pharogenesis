calculateWidth

	| min max |
	min _ SmallInteger maxVal.
	max _ SmallInteger minVal.
	self contours do: [:a | a do: [:p |
		p x > max ifTrue: [max _ p x].
		p x < min ifTrue: [min _ p x].
	]].
	^ max - min.
