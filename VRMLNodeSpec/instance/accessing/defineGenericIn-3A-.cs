defineGenericIn: aVRMLNode
	self assert:[aVRMLNode isGeneric].
	self attributes do:[:attr|
		attr isDynamic ifFalse:[aVRMLNode defineAttribute: attr].
	].