adjustRightX
	| shrink |
	shrink _ container right - maxRightX.
	lines do: [:line | line paddingWidth: (line paddingWidth - shrink)].
	container _ container withRight: maxRightX