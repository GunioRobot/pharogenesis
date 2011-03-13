updateStatus
	"Update that status in the receiver's header"

	(self topEditor == self) ifTrue: [
		(self firstSubmorph findA: ScriptStatusControl) ifNil: [self replaceRow1].
		self updateStatusMorph: (self firstSubmorph findA: ScriptStatusControl)
	]