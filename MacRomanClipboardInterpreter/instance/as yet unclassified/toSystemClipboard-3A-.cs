toSystemClipboard: aString

	| result |
	aString isOctetString ifTrue: [^ aString asOctetString isoToSqueak].

	result _ WriteStream on: (String new: aString size).
	aString do: [:each | each asciiValue < 256 ifTrue: [result nextPut: each isoToSqueak]].
	^ result contents.
