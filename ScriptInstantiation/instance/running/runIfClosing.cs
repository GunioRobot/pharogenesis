runIfClosing
	| result |
	(result _ status == #closing) ifTrue:
		[player perform: selector].
	^ result