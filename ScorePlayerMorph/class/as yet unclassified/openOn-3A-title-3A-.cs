openOn: aScore title: aString

	| player |
	player _ ScorePlayer onScore: aScore.
	(self new onScorePlayer: player title: aString) openInWorld.
