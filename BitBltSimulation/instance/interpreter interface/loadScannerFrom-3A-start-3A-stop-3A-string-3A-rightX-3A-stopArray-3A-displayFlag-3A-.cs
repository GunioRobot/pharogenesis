loadScannerFrom: bbObj
	start: start stop: stop string: string rightX: rightX
	stopArray: stopArray displayFlag: displayFlag

	self inline: false.
	"Load arguments and Scanner state"
	scanStart _ start.
	scanStop _ stop.
	scanString _ string.
	scanRightX _ rightX.
	scanStopArray _ stopArray.
	scanDisplayFlag _ displayFlag.
	interpreterProxy success: (
		(interpreterProxy isPointers: scanStopArray)
			and: [(interpreterProxy lengthOf: scanStopArray) >= 1]).
	scanXTable _ interpreterProxy fetchPointer: BBXTableIndex ofObject: bbObj.
	interpreterProxy success: (
		(interpreterProxy isPointers: scanXTable)
			and: [(interpreterProxy lengthOf: scanXTable) >= 1]).

	"width and sourceX may not be set..."
	interpreterProxy storeInteger: BBWidthIndex ofObject: bbObj withValue: 0.
	interpreterProxy storeInteger: BBSourceXIndex ofObject: bbObj withValue: 0.

	"Now load BitBlt state if displaying"
	scanDisplayFlag
		ifTrue: [interpreterProxy success: (self loadBitBltFrom: bbObj)]
		ifFalse: [bitBltOop _ bbObj.
				destX _ interpreterProxy fetchIntegerOrTruncFloat: BBDestXIndex ofObject: bbObj].
	^interpreterProxy failed not