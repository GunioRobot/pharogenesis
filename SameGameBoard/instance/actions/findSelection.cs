findSelection
	"find a possible selection and return it, or nil if no selection"

	| tile k testTile |
	0 to: rows-1 do:
		[:r |
		0 to: columns-1 do:
			[:c |
			tile _ self tileAt: c@r.
			tile disabled  ifFalse:
				[k _ tile color.
				c+1 < columns ifTrue:
					[testTile _ self tileAt: (c+1)@r.
					(testTile disabled not and: [testTile color = k]) ifTrue: [^ tile]].
				r+1 < rows ifTrue:
					[testTile _ self tileAt: c@(r+1).
					(testTile disabled not and: [testTile color = k]) ifTrue: [^ tile]]]]].
	 ^ nil
			