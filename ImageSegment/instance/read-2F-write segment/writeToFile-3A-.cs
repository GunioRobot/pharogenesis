writeToFile: shortName
	"The short name can't have any fileDelimiter characters in it.  It is remembered in case the segment must be brought in and then sent out again (see ClassDescription updateInstancesFrom:)."

	segmentName _ (shortName endsWith: '.seg')
		ifTrue: [shortName copyFrom: 1 to: shortName size - 4]
		ifFalse: [shortName].
	segmentName last isDigit ifTrue: [segmentName _ segmentName, '-'].
	self writeToFile.