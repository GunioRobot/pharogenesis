pickPointOnBounds: boundary
	"Chooses a random point so that an edge of this morph lies on the specified bounds"

	| side pos |

	"First choose which side to move the morph to"
	side _ (1 to: 4) atRandom.

	"Now choose where on that side to move to"
	((side = 1) or: [ side = 3 ])
			ifTrue: [ pos _ (0 to: ((boundary height) - (bounds height))) atRandom]
			ifFalse: [ pos _ (0 to: ((boundary width) - (bounds width))) atRandom ].

	"Now assemble the point)"
	"left"
	(side = 1) ifTrue: [ ^ (boundary left)@((boundary top) + pos) ].

	"top"
	(side = 2) ifTrue: [ ^ ((boundary left) + pos) @ (boundary top) ].

	"right"
	(side = 3) ifTrue: [ ^ ((boundary right) - (bounds width)) @ ((boundary top) + pos) ].

	"bottom"
	^ ((boundary left) + pos) @ ((boundary bottom) - (bounds height)).
