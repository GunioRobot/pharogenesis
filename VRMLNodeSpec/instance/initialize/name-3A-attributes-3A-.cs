name: aString attributes: aCollection
	name := aString.
	attributes := aCollection.
	attrDict := Dictionary new: attributes size.
	vrmlClass := VRMLUndefinedNode.
	aCollection do:[:attr| attrDict at: attr name put: attr].