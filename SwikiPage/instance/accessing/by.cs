by
	| who |
	who _ user class == String
					ifFalse: [address]
					ifTrue: [user].
		who ifNil: [who _ 'unknown user'].
	^who.
