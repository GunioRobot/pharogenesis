adjustTiles
	"reset tiles"

	| newSubmorphs count r c |

	submorphs do: "clear out all of the tiles."
		[:m | m privateOwner: nil].

	newSubmorphs _ OrderedCollection new.

	r _ 0.
	c _ 0.
	count _ columns * rows.

	1 to: count do:
				[:m |
				newSubmorphs add:
					(protoTile copy
						position: self position + (self protoTile extent * (c @ r));
						actionSelector: #tileClickedAt:newSelection:modifier:;
						arguments: (Array with: (c+1) @ (r+1));
						target: self;
						privateOwner: self).
				c _ c + 1.
				c >= columns ifTrue: [c _ 0. r _ r + 1]].
	submorphs _ newSubmorphs asArray.

