= aString 

	aString isString ifFalse: [^ false].

	^ (self multiStringCompare: self with: (MultiString from: aString) collated: nil) = 2.
