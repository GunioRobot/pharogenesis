adjustTiles
	"add or remove new protoTile submorphs to fill out my new bounds"

	| newSubmorphs requiredSubmorphs count r c |
	columns _ self width // protoTile width.
	rows _ self height // protoTile height.
	requiredSubmorphs _ rows * columns.
	newSubmorphs _ OrderedCollection new.
	r _ 0.
	c _ 0.
	self submorphCount > requiredSubmorphs
		ifTrue: "resized smaller -- delete rows or columns"
			[count _ 0.
			submorphs do:
				[:m | 
				count < requiredSubmorphs
					ifTrue:
						[m position: self position + (protoTile extent * (c @ r)).
						m arguments: (Array with: c @ r).
						newSubmorphs add: m]
					ifFalse: [m privateOwner: nil].
				count _ count + 1.
				c _ c + 1.
				c >= columns ifTrue: [c _ 0. r _ r + 1]]]
		ifFalse: "resized larger -- add rows or columns"
			[submorphs do:
				[:m |
				m position: self position + (self protoTile extent * (c @ r)).
				m arguments: (Array with: c @ r).
				newSubmorphs add: m.
				c _ c + 1.
				c >= columns ifTrue: [c _ 0. r _ r + 1]].
			1 to: (requiredSubmorphs - self submorphCount) do:
				[:m |
				newSubmorphs add:
					(protoTile copy
						position: self position + (self protoTile extent * (c @ r));
						actionSelector: #tileClickedAt:newSelection:;
						arguments: (Array with: c @ r);
						target: self;
						privateOwner: self).
				c _ c + 1.
				c >= columns ifTrue: [c _ 0. r _ r + 1]]].
	submorphs _ newSubmorphs asArray.
