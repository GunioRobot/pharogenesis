openOn: aScore title: aString
	| player |
	player _ ScorePlayer onScore: aScore.
	player play.  "start playing immediately"
	(self new onScorePlayer: player title: aString) openInWorld