tallyPixelValuesPrimitive: destRect into: valueTable
	"Tally the selected pixels of this form into the valueTable, which is
	a bitmap similar to a color map.  Since the underlying BitBlt function
	that performs the tally does not do bit-boundary clipping, the
	tallies for any word-boundary fringes must be subtracted."

	(BitBlt toForm: self)
		sourceForm: self;  "src must be given for color map ops"
		sourceOrigin: 0@0;
		colorMap: valueTable;
		combinationRule: 23;
		destRect: destRect;
		copyBits.
	^ valueTable