vrmlProtoCopy
	| attrCopy |
	attrCopy := Dictionary new: self attributes size.
	self attributes associationsDo:[:assoc|
		attrCopy at: assoc key put:  assoc value vrmlProtoCopy.
	].
	^self shallowCopy attributes: attrCopy.