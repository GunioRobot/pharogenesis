rotationCenter
	| pt |
	pt _ self transform localPointToGlobal: super rotationCenter.
	^pt - bounds origin / bounds extent asFloatPoint