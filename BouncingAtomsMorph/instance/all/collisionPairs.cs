collisionPairs
	"Return a list of pairs of colliding atoms, which are assumed to be circles of known radius. This version uses the morph's positions--i.e. the top-left of their bounds rectangles--rather than their centers."

	| count sortedAtoms radius twoRadii radiiSquared collisions p1 continue j p2 distSquared |
	count _ submorphs size.
	sortedAtoms _ submorphs asSortedCollection:
		[ :m1 :m2 | m1 position x < m2 position x].
	radius _ 8.
	twoRadii _ 2 * radius.
	radiiSquared _ radius squared * 2.
	collisions _ OrderedCollection new.
	1 to: count - 1 do: [ :i |
		m1 _ sortedAtoms at: i.
		p1 _ m1 position.
		continue _ (j _ i + 1) <= count.
		[continue] whileTrue: [
			m2 _ sortedAtoms at: j.
			p2 _ m2 position.
			(p2 x - p1 x) <= twoRadii  ifTrue: [
				distSquared _ (p1 x - p2 x) squared + (p1 y - p2 y) squared.
				distSquared < radiiSquared ifTrue: [
					collisions add: (Array with: m1 with: m2)].
				continue _ (j _ j + 1) <= count.
			] ifFalse: [
				continue _ false.
			].
		].
	].
	^ collisions