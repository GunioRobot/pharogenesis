maxAsciiFor: encoding

	| f |
	f _ (fontArray at: encoding+1).
	f ifNotNil: [^ f maxAscii].
	^ 0.
