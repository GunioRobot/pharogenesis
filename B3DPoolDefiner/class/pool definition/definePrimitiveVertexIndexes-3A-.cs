definePrimitiveVertexIndexes: dict
	"Define the indexes for primitive vertices"
	"B3DPoolDefiner initPool"
	self initFromSpecArray:
	#(
		"Full vertex size is 16 to simplify index computation"
		(PrimVertexSize 16)

		"Position"
		(PrimVtxPosition 0)
		(PrimVtxPositionX 0)
		(PrimVtxPositionY 1)
		(PrimVtxPositionZ 2)

		"Normal"
		(PrimVtxNormal 3)
		(PrimVtxNormalX 3)
		(PrimVtxNormalY 4)
		(PrimVtxNormalZ 5)

		"Tex coord"
		(PrimVtxTexCoords 6)
		(PrimVtxTexCoordU 6)
		(PrimVtxTexCoordV 7)

		"RasterPos"
		(PrimVtxRasterPos 8)
		(PrimVtxRasterPosX 8)
		(PrimVtxRasterPosY 9)
		(PrimVtxRasterPosZ 10)
		(PrimVtxRasterPosW 11)

		"Color"
		(PrimVtxColor32 12)
		"Clip flags"
		(PrimVtxClipFlags 13)

		"(Integer) window position"
		(PrimVtxWindowPosX 14)
		(PrimVtxWindowPosY 15)
	) in: dict