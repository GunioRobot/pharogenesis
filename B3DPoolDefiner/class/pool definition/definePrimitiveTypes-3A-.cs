definePrimitiveTypes: dict
	"Initialize the types of Primitives"
	"B3DPoolDefiner initPool"
	self initFromSpecArray:
	#(
		(PrimTypePoints 1)
		(PrimTypeLines 2)
		(PrimTypePolygon 3)
		(PrimTypeIndexedLines 4)
		(PrimTypeIndexedTriangles 5)
		(PrimTypeIndexedQuads 6)
		(PrimTypeMax 6)	"Max used primitive type"
	) in: dict.