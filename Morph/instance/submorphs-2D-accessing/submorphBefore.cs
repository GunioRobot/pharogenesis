submorphBefore
	"Return the submorph after (behind) me, or nil"
	| ii |
	owner ifNil: [^ nil].
	^ (ii _ owner submorphIndexOf: self) = 1 
		ifTrue: [nil]
		ifFalse: [owner submorphs at: ii-1].
	