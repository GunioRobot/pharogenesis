runIfOpening
	| result |
	(result _ status == #opening) ifTrue:
		[player perform: selector].
	^ result