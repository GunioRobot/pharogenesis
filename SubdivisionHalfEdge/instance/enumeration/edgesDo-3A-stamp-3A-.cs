edgesDo: aBlock stamp: timeStamp
	(quadEdge timeStamp = timeStamp) ifTrue:[^self].
	quadEdge timeStamp: timeStamp.
	aBlock value: self.
	self originNext edgesDo: aBlock stamp: timeStamp.
	self originPrev edgesDo: aBlock stamp: timeStamp.
	self destNext edgesDo: aBlock stamp: timeStamp.
	self destPrev edgesDo: aBlock stamp: timeStamp.