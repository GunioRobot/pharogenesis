revertToUnscriptedPlayerIfAppropriate
	| anInstance |
	((self class selectors size > 0) or: [self class instVarNames size > 0]) ifTrue: [^ self].
	anInstance _ UnscriptedPlayer new.
	anInstance initializeCostumesFrom: self.
	self become: anInstance