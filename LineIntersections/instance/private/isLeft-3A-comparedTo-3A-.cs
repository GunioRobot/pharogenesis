isLeft: dir1 comparedTo: dir2
	"Return true if dir1 is left of dir2"
	| det |
	det _ ((dir1 x * dir2 y) - (dir2 x * dir1 y)).
	"det = 0 ifTrue:[self error:'line on line']."
	^det <= 0