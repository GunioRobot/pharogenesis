copyFrom: start to: stop

	| n |
	n _ super copyFrom: start to: stop.
	n isOctetString ifTrue: [^ n asOctetString].
	^ n.
