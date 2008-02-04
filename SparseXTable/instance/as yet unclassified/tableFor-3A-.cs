tableFor: code

	| div t table |
	div := code // 65536.
	t := xTables at: div ifAbsent: [table := Array new: 65536 withAll: 0. xTables at: div put: table. table].
	^ t.
