defineClipConstants: dict
	"Initialize the clipper constants"
	"B3DPoolDefiner initPool"
	self initFromSpecArray:
	#(
		(InLeftBit		16r001)
		(OutLeftBit		16r002)
		(InRightBit		16r004)
		(OutRightBit		16r008)
		(InTopBit		16r010)
		(OutTopBit		16r020)
		(InBottomBit		16r040)
		(OutBottomBit	16r080)
		(InFrontBit		16r100)
		(OutFrontBit		16r200)
		(InBackBit		16r400)
		(OutBackBit		16r800)

		(InAllMask		16r555)
		(OutAllMask		16rAAA)
	) in: dict.