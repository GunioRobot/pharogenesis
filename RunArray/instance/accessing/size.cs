size
	| size |
	size _ 0.
	1 to: runs size do: [:i | size _ size + (runs at: i)].
	^size