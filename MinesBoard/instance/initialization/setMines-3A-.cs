setMines: notHere

	| count total c r sm |
	count _ 0.
	total _ self preferredMines.
	[count < total] whileTrue:[
		c _ columns atRandom.
		r _ rows atRandom.
		c@r = notHere ifFalse: [
			sm _ self tileAt: c@r.
			sm isMine ifFalse: [
				"sm color: Color red lighter lighter lighter lighter."
				sm isMine: true.
				count _ count + 1.]]
		].
	1 to: columns do: [ :col |
		1 to: rows do: [ :row |
			(self tileAt: col @ row) nearMines: (self findMines: (col @ row))
			]].
			