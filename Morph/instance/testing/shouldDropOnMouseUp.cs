shouldDropOnMouseUp
	| former |
	former _ self formerPosition ifNil:[^false].
	^(former dist: self position) > 10