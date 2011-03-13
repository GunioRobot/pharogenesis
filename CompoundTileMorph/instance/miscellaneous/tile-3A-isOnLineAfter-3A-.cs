tile: tile isOnLineAfter: previousTile
	"Return true if the given tile is not on the same line at the previous tile or if the previous tile is nil."

	| tileRow previousRow |
	previousTile ifNil: [^ true].
	tileRow _ tile owner.
	[tileRow isMemberOf: AlignmentMorph]
		whileFalse: [tileRow _ tileRow owner].  "find the owning row"
	previousRow _ previousTile owner.
	[previousRow isMemberOf: AlignmentMorph]
		whileFalse: [previousRow _ previousRow owner].  "find the owning row"
	^ tileRow ~~ previousRow
