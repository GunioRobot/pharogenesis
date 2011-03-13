initializeIndexTables
	IndexTables := Array new: 4.
	IndexTables at: 1 put:
		#(-1 2).
	IndexTables at: 2 put:
		#(-1 -1 2 4).
	IndexTables at: 3 put:
		#(-1 -1 -1 -1 2 4 6 8).
	IndexTables at: 4 put:
		#(-1 -1 -1 -1 -1 -1 -1 -1 1 2 4 6 8 10 13 16).