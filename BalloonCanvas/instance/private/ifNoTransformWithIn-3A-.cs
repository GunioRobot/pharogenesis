ifNoTransformWithIn: box
	"Return true if the current transformation does not affect the given bounding box"
	| delta |
	"false ifFalse:[^false]."
	transform isNil ifTrue:[^true].
	delta _ (transform localPointToGlobal: box origin) - box origin.
	^(transform localPointToGlobal: box corner) - box corner = delta