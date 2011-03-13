positionIn: aBox horizontalPlacement: horiz verticalPlacement: vert
	| xCoord yCoord |

	horiz == #left
		ifTrue:	[xCoord _ aBox left].
	horiz == #leftCenter
		ifTrue:	[xCoord _ aBox left + (aBox width // 4)].
	horiz == #center
		ifTrue:	[xCoord _ (aBox left + aBox right) // 2].
	horiz == #rightCenter
		ifTrue:	[xCoord _ aBox left + ((3 * aBox width) // 4)].
	horiz == #right
		ifTrue:	[xCoord _ aBox right].

	vert == #top
		ifTrue:	[yCoord _ aBox top].
	vert == #topCenter
		ifTrue:	[yCoord _ aBox top + (aBox height // 4)].
	vert == #center
		ifTrue:	[yCoord _ (aBox top + aBox bottom) // 2].
	vert == #bottomCenter
		ifTrue:	[yCoord _ aBox top + ((3 * aBox height) // 4)].
	vert == #bottom
		ifTrue:	[yCoord _ aBox bottom].

	^ xCoord asInteger @ yCoord asInteger