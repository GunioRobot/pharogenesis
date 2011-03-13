firstTurtleAtX: xPos y: yPos 

	| w t x y index |
	"create turtlesAtPatchCache if necessary"
	turtlesAtPatchCache ifNil: [
		turtlesAtPatchCache := Array new: (dimensions x * dimensions y) withAll: nil.
		turtlesAtPatchCacheValid := false].

	w := dimensions y.
	turtlesAtPatchCacheValid ifFalse: [
		turtlesAtPatchCache atAllPut: nil.
		"cache not yet computed for this step; make linked list of turtles for each patch"
		1 to: turtles size do: [:i |
			t := turtles at: i.
			x := t x truncated.
			y := t y truncated.
			index := (w * y) + x + 1.
			t nextTurtle: (turtlesAtPatchCache at: index).
			turtlesAtPatchCache at: index put: t].
		turtlesAtPatchCacheValid := true].

	x := xPos truncated.
	y := yPos truncated.
	index := (w * y) + x + 1.
	^ turtlesAtPatchCache at: index
