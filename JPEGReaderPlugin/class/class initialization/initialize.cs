initialize
	"JPEGReaderPlugin initialize"
	DCTSize _ 8.
	MaxSample _ (2 raisedToInteger: DCTSize) - 1.
	SampleOffset _ MaxSample // 2.
	DCTSize2 _ DCTSize squared.
	ConstBits _ 13.
	Pass1Bits _ 2.
	Pass1Div _ 1 bitShift: ConstBits - Pass1Bits.
	Pass2Div _ 1 bitShift: ConstBits + Pass1Bits + 3.

	"fixed-point Inverse Discrete Cosine Transform (IDCT) constants"
	FIXn0n298631336 _ 2446.
	FIXn0n390180644 _ 3196.
	FIXn0n541196100 _ 4433.
	FIXn0n765366865 _ 6270.
	FIXn0n899976223 _ 7373.
	FIXn1n175875602 _ 9633.
	FIXn1n501321110 _ 12299.
	FIXn1n847759065 _ 15137.
	FIXn1n961570560 _ 16069.
	FIXn2n053119869 _ 16819.
	FIXn2n562915447 _ 20995.
	FIXn3n072711026 _ 25172.

	"fixed-point color conversion constants"
	FIXn0n34414 _ 22554.
	FIXn0n71414 _ 46802.
	FIXn1n40200 _ 91881.
	FIXn1n77200 _  116130.

	CurrentXIndex _ 0.
	CurrentYIndex _ 1.
	HScaleIndex _ 2.
	VScaleIndex _ 3.
	MCUBlockIndex _ 4.
	BlockWidthIndex _ 5.
	MCUWidthIndex _ 8.
	PriorDCValueIndex _ 10.
	MinComponentSize _ 11.

	RedIndex _ 0.
	GreenIndex _ 1.
	BlueIndex _ 2.

	MaxMCUBlocks _ 128.
	MaxBits _ 16.