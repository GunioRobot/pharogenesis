initialize
	"JPEGReadWriter initialize"
	"general constants"
	DCTSize _ 8.
	MaxSample _ (2 raisedToInteger: DCTSize) - 1.
	SampleOffset _ MaxSample // 2.
	FloatSampleOffset _ SampleOffset asFloat.
	DCTSize2 _ DCTSize squared.
	QuantizationTableSize _ 4.
	HuffmanTableSize _ 4.

	"floating-point Inverse Discrete Cosine Transform (IDCT) constants"
	ConstBits _ 13.
	Pass1Bits _ 2.
	DCTK1 _ 2 sqrt.
	DCTK2 _ 1.847759065.
	DCTK3 _ 1.082392200.
	DCTK4 _ -2.613125930.
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

	"reordering table from JPEG zig-zag order"
	JPEGNaturalOrder _ #(
		1 2 9 17 10 3 4 11
		18 25 33 26 19 12 5 6
		13 20 27 34 41 49 42 35
		28 21 14 7 8 15 22 29
		36 43 50 57 58 51 44 37
		30 23 16 24 31 38 45 52
		59 60 53 46 39 32 40 47
		54 61 62 55 48 56 63 64).

	"scale factors for the values in the Quantization Tables"
	QTableScaleFactor _ (0 to: DCTSize-1) collect:
		[:k | k = 0
			ifTrue: [1.0]
			ifFalse: [(k * Float pi / 16) cos * 2 sqrt]].

	"dithering masks"
	(DitherMasks _ Dictionary new)
		add: 0 -> 0;
		add: 1 -> 127;
		add: 2 -> 63;
		add: 4 -> 63;
		add: 8 -> 31;
		add: 16 -> 7;
		add: 32 -> 0.

	"dictionary of marker parsers"
	(JFIFMarkerParser _ Dictionary new)
		add: (16r01 -> #parseNOP);
		add: (16rC0 -> #parseStartOfFile);
		add: (16rC4 -> #parseHuffmanTable);
		addAll: ((16rD0 to: 16rD7) collect: [:m | Association key: m value: #parseNOP]);
		add: (16rD8 -> #parseStartOfInput);
		add: (16rD9 -> #parseEndOfInput);
		add: (16rDA -> #parseStartOfScan);
		add: (16rDB -> #parseQuantizationTable);
		add: (16rDD -> #parseDecoderRestartInterval);
		add: (16rE0 -> #parseAPPn);
		add: (16rE1 -> #parseAPPn)