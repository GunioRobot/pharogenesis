initialize
	"BitBltSimulation initialize"
 
	self initializeRuleTable.

	"Mask constants"
	AllOnes _ 16rFFFFFFFF.
	BinaryPoint _ 14.
	FixedPt1 _ 1 << BinaryPoint.  "Value of 1.0 in Warp's fixed-point representation"
 
	"Indices into stopConditions for scanning"
	EndOfRun _ 257.
	CrossedX _ 258.
 
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
	BBWarpBase _ 15.
	BBLastIndex _ 15.
	BBXTableIndex _ 16.