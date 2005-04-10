toSystemClipboard: aString

	| result converter r |
	aString isAsciiString ifTrue: [^ aString asOctetString]. "optimization"

	result _ WriteStream on: (String new: aString size).
	converter _ CP1250TextConverter new.
	aString do: [:each |
		r _ converter fromSqueak: each.
		r charCode < 255 ifTrue: [
		result nextPut: r squeakToMac]].
	^ result contents.
