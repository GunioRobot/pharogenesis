encoding

	| enc |
	enc _ self getEncoding.
	enc ifNil: [ ^ nil ].
	^ enc asLowercase.