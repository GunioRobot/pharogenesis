toSystemClipboard: aString

	| result |
	aString isOctetString ifTrue: [^ aString asOctetString squeakToMac].

	result _ WriteStream on: (String new: aString size).
	aString do: [:each | each asciiValue < 256 ifTrue: [result nextPut: each squeakToMac]].
	^ result contents.
