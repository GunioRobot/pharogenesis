Object
	subclass: #BitBltSimulation
	instanceVariableNames:
		'destForm sourceForm halftoneForm combinationRule destX destY width height sourceX sourceY clipX clipY clipWidth clipHeight sourceBits sourceRaster sourcePixSize destBits destRaster destPixSize pixPerWord bitCount skew mask1 mask2 preload nWords hDir vDir sourceIndex sourceDelta destIndex destDelta sx sy dx dy bbW bbH srcWidth srcHeight halftoneHeight noSource noHalftone halftoneBase colorMap cmBitsPerColor srcBitIndex scanStart scanStop scanString scanRightX scanStopArray scanDisplayFlag scanXTable stopCode bitBltOop affectedL affectedR affectedT affectedB interpreterProxy opTable '
	classVariableNames:
		'AllOnes BBClipHeightIndex BBClipWidthIndex BBClipXIndex BBClipYIndex BBColorMapIndex BBDestFormIndex BBDestXIndex BBDestYIndex BBHalftoneFormIndex BBHeightIndex BBLastIndex BBRuleIndex BBSourceFormIndex BBSourceXIndex BBSourceYIndex BBWarpBase BBWidthIndex BBXTableIndex BinaryPoint CrossedX EndOfRun FixedPt1 FormBitsIndex FormDepthIndex FormHeightIndex FormWidthIndex OpTable OpTableSize '
	poolDictionaries: ''
	category: 'Squeak-Interpreter'