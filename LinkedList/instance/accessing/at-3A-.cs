at: index

	| i |
	i _ 0.
	self do: [:link |
		(i _ i + 1) = index ifTrue: [^ link]].
	^ self errorSubscriptBounds: index