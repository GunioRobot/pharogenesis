storeFillStateInto: fillOop
	| fillIndex leftX rightX |
	self inline: false.
	fillIndex _ self lastExportedFillGet.
	leftX _ self lastExportedLeftXGet.
	rightX _ self lastExportedRightXGet.

	(interpreterProxy slotSizeOf: fillOop) < FTBalloonFillDataSize 
		ifTrue:[^interpreterProxy primitiveFail].
	interpreterProxy storeInteger: FTIndexIndex ofObject: fillOop withValue: 
		(self objectIndexOf: fillIndex).
	interpreterProxy storeInteger: FTMinXIndex ofObject: fillOop withValue: leftX.
	interpreterProxy storeInteger: FTMaxXIndex ofObject: fillOop withValue: rightX.
	interpreterProxy storeInteger: FTYValueIndex ofObject: fillOop withValue: self currentYGet.