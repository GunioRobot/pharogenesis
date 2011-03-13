compile: aClassSelector method: aString
	self assertClass: aClassSelector.
	(Smalltalk at: aClassSelector) compile: aString.