informUserDuring: aBlock
	self class isSilent ifTrue:[^aBlock value].
	Utilities informUserDuring:[:bar|
		progress _ bar.
		aBlock value].
	progress _ nil.