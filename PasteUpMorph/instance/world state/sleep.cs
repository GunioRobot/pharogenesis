sleep

	self canvas ifNil: [^ self  "already called (clean this up)"].
	Cursor normal show.	"restore the normal cursor"
	(turtleTrailsForm ~~ nil and: [self confirm: 'May I clear the pen trails
in this worldState to save space?']) ifTrue: [self clearTurtleTrails].
	self canvas: nil.		"free my canvas to save space"
	self fullReleaseCachedState.
