endGameFor: team
	"Return true if we are in the end game (all players within 1 of home triangle)."

	| goalLoc |
	goalLoc _ homes atWrap: team+3.  "Farthest cell across the board"
	(teams at: team)
		do: [:boardLoc | (self distFrom: boardLoc to: goalLoc) > 4 ifTrue: [^ false]].
	^ true