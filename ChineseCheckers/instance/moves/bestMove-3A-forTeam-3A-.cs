bestMove: ply forTeam: team
	| score bestScore bestMove |
	bestScore := -999.
	(teams at: team) do:
		[:boardLoc |
		(self allMovesFrom: boardLoc) do:
			[:move |
			score := self score: move for: team.
			(score > -99 and: [ply > 0]) ifTrue: 
				[score := score  "Add 0.7 * score of next move (my guess)"
					+ (0 max: ((self score: ((self copyBoard makeMove: move)
							bestMove: ply - 1 forTeam: team) for: team) * 0.7))].
			score > bestScore ifTrue:
				[bestScore := score.  bestMove := move]]].
	^ bestMove