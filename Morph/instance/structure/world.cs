world
	"Return the WorldMorph that contains this morph, or nil if this morph is not in a world."

	| o |
	o _ self root owner.
	o ifNil: [^ nil].
	o isWorldMorph ifTrue: [^ o].
	o isHandMorph ifTrue: [^ o owner].
