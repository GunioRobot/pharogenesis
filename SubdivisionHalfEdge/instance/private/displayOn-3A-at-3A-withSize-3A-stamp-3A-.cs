displayOn: aGraphicsContext at: aPoint withSize: scaling stamp: timeStamp

	| v1 v2 |
	(quadEdge timeStamp = timeStamp) ifTrue:[^self].
	quadEdge timeStamp: timeStamp.
	v1 := self origin.
	v2 := self destination.
	aGraphicsContext 
		displayLineFrom: (v1 * scaling)+aPoint
		to: (v2 * scaling) + aPoint.
	self originNext displayOn: aGraphicsContext at: aPoint withSize: scaling stamp: timeStamp.
	self originPrev displayOn: aGraphicsContext at: aPoint withSize: scaling stamp: timeStamp.
	self destNext displayOn: aGraphicsContext at: aPoint withSize: scaling stamp: timeStamp.

	self destPrev displayOn: aGraphicsContext at: aPoint withSize: scaling stamp: timeStamp.