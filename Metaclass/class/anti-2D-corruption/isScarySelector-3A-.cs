isScarySelector: newbieSelector

	"Return true if newbieSelector is already a part of Metaclass protocol."
	(Metaclass includesSelector: newbieSelector) ifTrue: [^ true].
	(ClassDescription includesSelector: newbieSelector) ifTrue: [^ true].
	(Behavior includesSelector: newbieSelector) ifTrue: [^ true].
	^ false
