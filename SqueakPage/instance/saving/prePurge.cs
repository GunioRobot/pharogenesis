prePurge
	"Return self if ready to be purged, or nil if not"

	self isContentsInMemory ifFalse: [^ nil].
	contentsMorph ifNil: [^ nil].  "out already"
	url ifNil: [^ nil].	"just to be safe"
	^ (World ~~ nil and: [contentsMorph world == World]) 
		ifTrue: [nil "showing now"] ifFalse: [self]