firstTurtleAtX: xPos y: yPos 

	| w t x y index |
	"create turtlesAtPatchCache if necessary"
	turtlesAtPatchCache ifNil: [
		turtlesAtPatchCache _ Array new: (dimensions x * dimensions y) withAll: nil.
		turtlesAtPatchCacheValid _ false].

	w _ dimensions y.
	turtlesAtPatchCacheValid ifFalse: [
		turtlesAtPatchCache atAllPut: nil.
		"cache not yet computed for this step; make linked list of turtles for each patch"
		1 to: turtles size do: [:i |
			t _ turtles at: i.
			x _ t x truncated.
			y _ t y truncated.
			index _ (w * y) + x + 1.
			t nextTurtle: (turtlesAtPatchCache at: index).
			turtlesAtPatchCache at: index put: t].
		turtlesAtPatchCacheValid _ true].

	x _ xPos truncated.
	y _ yPos truncated.
	index _ (w * y) + x + 1.
	^ turtlesAtPatchCache at: index
