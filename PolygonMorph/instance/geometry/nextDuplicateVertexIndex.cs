nextDuplicateVertexIndex
	vertices
		doWithIndex: [:vert :index | ((index between: 2 and: vertices size - 1)
					and: [| epsilon v1 v2 | 
						v1 _ vertices at: index - 1.
						v2 _ vertices at: index + 1.
						epsilon _ ((v1 x - v2 x) abs max: (v1 y - v2 y) abs)
									// 32 max: 1.
						vert
							onLineFrom: v1
							to: v2
							within: epsilon])
				ifTrue: [^ index]].
	^ 0