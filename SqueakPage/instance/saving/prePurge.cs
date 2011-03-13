prePurge
	"Return self if ready to be purged, or nil if not"

	self isContentsInMemory ifFalse: [^ nil].
	contentsMorph ifNil: [^ nil].  "out already"
	url ifNil: [^ nil].	"just to be safe"
	^ (Display bestGuessOfCurrentWorld ~~ nil and: [contentsMorph world == Display bestGuessOfCurrentWorld]) 
		ifTrue: [nil "showing now"] ifFalse: [self]