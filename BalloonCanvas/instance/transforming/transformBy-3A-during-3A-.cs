transformBy: aDisplayTransform during: aBlock
	| myTransform result |
	myTransform _ transform.
	self transformBy: aDisplayTransform.
	result _ aBlock value: self.
	transform _ myTransform.
	^result