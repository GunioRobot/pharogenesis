subdivideToBeMonoton
	"Subdivide the receiver at it's extreme point"
	| v1 v2 t other |
	v1 _ (via - start).
	v2 _ (end - via).
	t _ (v1 y / (v2 y - v1 y)) negated asFloat.
	other _ self subdivideAt: t.
	self isMonoton ifFalse:[self halt].
	other isMonoton ifFalse:[self halt].
	^other