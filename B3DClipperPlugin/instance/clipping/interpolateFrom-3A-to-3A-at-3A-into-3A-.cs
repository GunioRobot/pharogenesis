interpolateFrom: last to: next at: t into: out
	"Interpolate the primitive vertices last/next at the parameter t"
	| delta rgbaLast lastValue rgbaNext nextValue newValue x y z w w2 flags |
	self var: #last declareC:'float *last'.
	self var: #next declareC:'float *next'.
	self var: #out declareC:'float *out'.
	self var: #t declareC: 'double t'.
	self var: #delta declareC: 'double delta'.
	self var: #rgbaLast declareC:'unsigned int rgbaLast'.
	self var: #rgbaNext declareC:'unsigned int rgbaNext'.
	self var: #lastValue declareC:'unsigned int lastValue'.
	self var: #nextValue declareC:'unsigned int nextValue'.
	self var: #newValue declareC:'unsigned int newValue'.
	self var: #x declareC:'double x'.
	self var: #y declareC:'double y'.
	self var: #z declareC:'double z'.
	self var: #w declareC:'double w'.
	self var: #w2 declareC:'double w2'.
	"Interpolate raster position"
	delta _ (next at: PrimVtxRasterPosX) - (last at: PrimVtxRasterPosX).
	x _ (last at: PrimVtxRasterPosX) + (delta * t).
	out at: PrimVtxRasterPosX put: (self cCoerce: x to: 'float').
	delta _ (next at: PrimVtxRasterPosY) - (last at: PrimVtxRasterPosY).
	y _ (last at: PrimVtxRasterPosY) + (delta * t).
	out at: PrimVtxRasterPosY put: (self cCoerce: y to: 'float').
	delta _ (next at: PrimVtxRasterPosZ) - (last at: PrimVtxRasterPosZ).
	z _ (last at: PrimVtxRasterPosZ) + (delta * t).
	out at: PrimVtxRasterPosZ put: (self cCoerce: z to: 'float').
	delta _ (next at: PrimVtxRasterPosW) - (last at: PrimVtxRasterPosW).
	w _ (last at: PrimVtxRasterPosW) + (delta * t).
	out at: PrimVtxRasterPosW put: (self cCoerce: w to: 'float').
	"Determine new clipFlags"
	w2 _ 0.0 - w.
	flags _ 0.
	x >= w2 ifTrue:[flags _ flags bitOr: InLeftBit] ifFalse:[flags _ flags bitOr: OutLeftBit].
	x <= w ifTrue:[flags _ flags bitOr: InRightBit] ifFalse:[flags _ flags bitOr: OutRightBit].
	y >= w2 ifTrue:[flags _ flags bitOr: InBottomBit] ifFalse:[flags _ flags bitOr: OutBottomBit].
	y <= w ifTrue:[flags _ flags bitOr: InTopBit] ifFalse:[flags _ flags bitOr: OutTopBit].
	z >= w2 ifTrue:[flags _ flags bitOr: InFrontBit] ifFalse:[flags _ flags bitOr: OutFrontBit].
	z <= w ifTrue:[flags _ flags bitOr: InBackBit] ifFalse:[flags _ flags bitOr: OutBackBit].
	(self cCoerce: out to: 'int *') at: PrimVtxClipFlags put: flags.

	"Interpolate color"
	rgbaLast _ (self cCoerce: last to:'unsigned int *') at: PrimVtxColor32.
	lastValue _ rgbaLast bitAnd: 255. rgbaLast _ rgbaLast >> 8.
	rgbaNext _ (self cCoerce: next to: 'unsigned int *') at: PrimVtxColor32.
	nextValue _ rgbaNext bitAnd: 255. rgbaNext _ rgbaNext >> 8.
	delta _ (self cCoerce: (nextValue - lastValue) to:'int') * t.
	newValue _ (lastValue + delta) asInteger.

	lastValue _ rgbaLast bitAnd: 255. rgbaLast _ rgbaLast >> 8.
	nextValue _ rgbaNext bitAnd: 255. rgbaNext _ rgbaNext >> 8.
	delta _ (self cCoerce: (nextValue - lastValue) to:'int') * t.
	newValue _ newValue + ((lastValue + delta) asInteger << 8).

	lastValue _ rgbaLast bitAnd: 255. rgbaLast _ rgbaLast >> 8.
	nextValue _ rgbaNext bitAnd: 255. rgbaNext _ rgbaNext >> 8.
	delta _ (self cCoerce: (nextValue - lastValue) to:'int') * t.
	newValue _ newValue + ((lastValue + delta) asInteger << 16).

	lastValue _ rgbaLast bitAnd: 255.
	nextValue _ rgbaNext bitAnd: 255.
	delta _ (self cCoerce: (nextValue - lastValue) to:'int') * t.
	newValue _ newValue + ((lastValue + delta) asInteger << 24).

	(self cCoerce: out to:'unsigned int*') at: PrimVtxColor32 put: newValue.

	"Interpolate texture coordinates"
	delta _ (next at: PrimVtxTexCoordU) - (last at: PrimVtxTexCoordU).
	out at: PrimVtxTexCoordU put: (self cCoerce: (last at: PrimVtxTexCoordU) + (delta * t) to:'float').
	delta _ (next at: PrimVtxTexCoordV) - (last at: PrimVtxTexCoordV).
	out at: PrimVtxTexCoordV put: (self cCoerce: (last at: PrimVtxTexCoordV) + (delta * t) to:'float').
