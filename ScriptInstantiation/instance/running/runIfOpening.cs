runIfOpening
	| result |
	(result _ status == #opening) ifTrue:
		[player triggerScript: selector].
	^ result