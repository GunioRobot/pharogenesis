nextColorMatrix: usingAlpha
	| hadAlpha transform |
	hadAlpha _ hasAlpha.
	hasAlpha _ usingAlpha.
	transform _ self nextColorMatrix.
	hasAlpha _ hadAlpha.
	^transform