teams: teamsPlaying autoPlay: ifAuto
	"Initialize board, teams, steps, jumps"
	| p q teamInPlay |
	colors _ (#(gray) , #(red green blue cyan magenta yellow white) shuffled)
				collect: [:c | Color perform: c].  "New set of colors each time."
	self removeAllMorphs.  "eg, from previous game."
	board := (1 to: 19) collect: [:i | Array new: 19].
	sixDeltas := {0@1. -1@1. -1@0. 0@-1. 1@-1. 1@0}.
	homes := {14@2. 18@6. 14@14. 6@18. 2@14. 6@6}.
	teams := (1 to: 6) collect: [:i | OrderedCollection new].
	autoPlay := (1 to: 6) collect: [:i | false].
	1 to: 6 do:
		[:team | p:= homes at: team.
		(teamInPlay := teamsPlaying includes: team) ifTrue:
			[autoPlay at: team put: (ifAuto at: (teamsPlaying indexOf: team))].
		"Place empty cells in rhombus extending out from each
		home, and occupied cells in active home triangles."
		1 to: 5 do: [:i | q := p.
			1 to: 5 do: [:j |
				(teamInPlay and: [j <= (5 - i)])
					ifTrue: [self at: q put: team.
							(teams at: team) add: q.
							self addMorph:
								((ChineseCheckerPiece
									newBounds: ((self cellPointAt: q) extent: self pieceSize)
									color: (colors at: team+1))
										setBoard: self loc: q)]
					ifFalse: [self at: q put: 0].
				q := q + (sixDeltas at: team).  "right,forward"].
			p := p + (sixDeltas atWrap: team+1).  "left,forward"].
		teams at: team put: (teams at: team) asArray].
	whoseMove _ teamsPlaying first.
	self addMorph:
		((ChineseCheckerPiece
			newBounds: ((self cellPointAt: self turnIndicatorLoc) extent: self pieceSize)
			color: (colors at: whoseMove+1))
				setBoard: self loc: self turnIndicatorLoc).
	plannedMove _ nil.
	self changed