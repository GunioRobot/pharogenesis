d
	| r |
	ra <= 0.0 ifTrue: [^ 1.0].
	r _ 1.0 - ro / ra.
	^ 1.0 - (r / (r exp - 1.0))