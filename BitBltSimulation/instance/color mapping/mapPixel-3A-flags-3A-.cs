mapPixel: sourcePixel flags: mapperFlags
	"Color map the given source pixel."
	| pv |
	self inline: true.
	pv _ sourcePixel.
	(mapperFlags bitAnd: ColorMapPresent) ~= 0 ifTrue:[
		(mapperFlags bitAnd: ColorMapFixedPart) ~= 0 ifTrue:[
			pv _ self rgbMapPixel: sourcePixel flags: mapperFlags.
			"avoid introducing transparency by color reduction"
			(pv = 0 and:[sourcePixel ~= 0]) ifTrue:[pv _ 1]].
		(mapperFlags bitAnd: ColorMapIndexedPart) ~= 0
			ifTrue:[pv _ cmLookupTable at: (pv bitAnd: cmMask)].
	].
	^pv