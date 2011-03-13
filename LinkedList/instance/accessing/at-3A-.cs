at: index

	| i |
	i := 0.
	self do: [:link |
		(i := i + 1) = index ifTrue: [^ link]].
	^ self errorSubscriptBounds: index