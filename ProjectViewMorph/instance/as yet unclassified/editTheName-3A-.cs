editTheName: evt

	self isTheRealProjectPresent ifFalse: [
		^self inform: 'The project is not present and may not be renamed now'
	].
	self addProjectNameMorph launchMiniEditor: evt.