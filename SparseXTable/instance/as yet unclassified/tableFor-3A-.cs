tableFor: code

	| div t table |
	div _ code // 65536.
	t _ xTables at: div ifAbsent: [table _ Array new: 65536 withAll: 0. xTables at: div put: table. table].
	^ t.
