translateBy: amount
	vertices do:[:vtx| vtx += amount].
	bBox ifNotNil:[bBox _ bBox translateBy: amount].