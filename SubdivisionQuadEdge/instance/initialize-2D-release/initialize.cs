initialize
	edges := Array new: 4.
	1 to: 4 do:[:i| edges at: i put: (self edgeClass new id: i owner: self)].
	(edges at: 1) next: (edges at: 1).
	(edges at: 2) next: (edges at: 4).
	(edges at: 3) next: (edges at: 3).
	(edges at: 4) next: (edges at: 2).
	timeStamp := 0.
	flags _ 0.