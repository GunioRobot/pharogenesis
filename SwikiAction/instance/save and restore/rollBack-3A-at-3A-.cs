rollBack: aDate at: aTime
	"Roll back the entire server to a previous state.  This does not erase data, just moves an older page to the end."

	| folder dir rep page |
	folder _ (ServerAction serverDirectory), name.
	dir _ FileDirectory on: folder.
	dir fileNames do: [:fName |
		rep _ fName detect: [:char | char isDigit not] ifNone: [$3].
		rep isDigit ifTrue: ["all are digits"
			page _ urlmap atID: fName.
			page rollBack: aDate at: aTime]].
