toSystemClipboard: aString

	| result converter r |

	aString isAsciiString ifTrue: [^ aString asOctetString]. "optimization"

	result _ WriteStream on: (String new: aString size).
	converter _ ISO88592TextConverter new.
	aString do: [:each |
		r _ converter fromSqueak: each.].
	^ result contents.
