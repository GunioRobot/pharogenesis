merge: aKeyedTree
	"Merge the given tree into the receiver, overwriting or extending elements as needed."

	|subtree|
	aKeyedTree keysAndValuesDo: [:k :v |
		(v isKindOf: KeyedTree)
			ifTrue: [subtree := self at: k ifAbsentPut: [v species new].
				 	(subtree isKindOf: KeyedTree) not
						ifTrue: [subtree := self at: k put: v species new].
					subtree merge: v]
			ifFalse: [self at: k put: v]]