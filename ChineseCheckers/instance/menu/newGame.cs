newGame
	"Reset the board, with same teams."

	| teamNumbers |
	teamNumbers _ (1 to: 6) reject: [:i | (teams at: i) isEmpty].
	self teams: teamNumbers
		 autoPlay: (teamNumbers collect: [:i | autoPlay at: i]).
