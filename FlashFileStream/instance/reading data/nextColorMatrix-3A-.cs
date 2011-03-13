nextColorMatrix: usingAlpha
	| hadAlpha transform |
	hadAlpha := hasAlpha.
	hasAlpha := usingAlpha.
	transform := self nextColorMatrix.
	hasAlpha := hadAlpha.
	^transform