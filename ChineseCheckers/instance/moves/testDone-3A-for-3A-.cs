testDone: teamLocs for: team
	"Return true if we are done (all players in home triangle)."

	| goalLoc |
	goalLoc _ homes atWrap: team+3.
	teamLocs
		do: [:boardLoc | (self distFrom: boardLoc to: goalLoc) > 3 ifTrue: [^ false]].
	^ true