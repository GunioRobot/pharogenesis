returnAt: stopIndex lastIndex: lastIndex left: left top: top

	stopCode _ interpreterProxy stObject: scanStopArray at: stopIndex.
	interpreterProxy failed ifTrue: [^ nil].
	interpreterProxy storeInteger: BBLastIndex ofObject: bitBltOop withValue: lastIndex.
	scanDisplayFlag ifTrue: [
		"Now we know extent of affected rectangle"
		affectedL _ left.
		affectedR _ bbW + dx.
		affectedT _ top.
		affectedB _ bbH + dy.
	].