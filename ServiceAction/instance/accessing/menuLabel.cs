menuLabel
	| l sh |
	l := self text.
	l size > 50 ifTrue: [l := (l first: 47), '...'].	
	sh := self shortcut.
	sh := (sh isNil or: [sh isEmpty]) ifTrue: [''] ifFalse: [' (', sh, ')'].
	^ l capitalized, sh