size
	| size |
	(self type = #done)
		ifTrue: [^ 0].
	self type: #done.
	self subTriangles ifNil: [^ 1]
		ifNotNil: 
			[size _ 0.
			self subTriangles do: [:subTriangle | size _ size + subTriangle size].
			^ size + 1]