initialize
	"BitBltSimulation initialize"
  
	self initializeRuleTable.

	"Mask constants"
	AllOnes _ 16rFFFFFFFF.
	BinaryPoint _ 14.
	FixedPt1 _ 1 << BinaryPoint.  "Value of 1.0 in Warp's fixed-point representation"
 
	"Form fields"
	FormBitsIndex _ 0.
	FormWidthIndex _ 1.
	FormHeightIndex _ 2.
	FormDepthIndex _ 3.
 
	"BitBlt fields"
	BBDestFormIndex _ 0.
	BBSourceFormIndex _ 1.
	BBHalftoneFormIndex _ 2.
	BBRuleIndex _ 3.
	BBDestXIndex _ 4.
	BBDestYIndex _ 5.
	BBWidthIndex _ 6.
	BBHeightIndex _ 7.
	BBSourceXIndex _ 8.
	BBSourceYIndex _ 9.
	BBClipXIndex _ 10.
	BBClipYIndex _ 11.
	BBClipWidthIndex _ 12.
	BBClipHeightIndex _ 13.
	BBColorMapIndex _ 14.

	FXSourceMapIndex _ 15.
	FXDestMapIndex _ 16.
	FXWarpQuadIndex _ 17.
	FXWarpQualityIndex _ 18.
	FXSourceKeyIndex _ 19.
	FXDestKeyIndex _ 20.
	FXSourceAlphaIndex _ 21.
	FXTallyMapIndex _ 22.

	"RGBA indexes"
	RedIndex _ 0.
	GreenIndex _ 1.
	BlueIndex _ 2.
	AlphaIndex _ 3.

	"Color cache"
	ColorCacheSize _ 512. "Should be at least 256 and must be power of two"
	ColorCacheMask _ ColorCacheSize - 1.
	InvalidColorCacheEntry _ 16r01EC1B55.
