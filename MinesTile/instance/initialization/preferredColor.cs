preferredColor
		"PreferredColor _ nil  <-- to reset cache"
	PreferredColor ifNil:
		["This actually takes a while to compute..."
		PreferredColor _ Color gray lighter lighter lighter].
	^ PreferredColor