mouseOverHalosEnabled
	self presenter ifNotNil: [^ presenter mouseOverHalosEnabled].
	^ false.