morphsBearingPlayers

	| c |
	c _ OrderedCollection new.
	self allMorphsWithPlayersDo: [:e :p | c add: e].
	^ c asArray.
