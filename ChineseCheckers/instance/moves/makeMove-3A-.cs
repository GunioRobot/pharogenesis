makeMove: move
	| team |
	team := self at: move first.
	self at: move last put: team.
	self at: move first put: 0.
	(teams at: team) replaceAll: move first with: move last