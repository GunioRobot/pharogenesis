copyBoard
	"Return a copy of the board for the purpose of looking ahead one or more moves."

	^ self copy
		board: (board collect: [:row | row copy])
		teams: (teams collect: [:team | team copy])