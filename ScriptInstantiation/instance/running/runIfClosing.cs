runIfClosing
	| result |
	(result _ status == #closing) ifTrue:
		[player triggerScript: selector].
	^ result