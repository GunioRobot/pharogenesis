defaultAction
	| s |
	s _ self syntaxError.
	^ s class open: s
