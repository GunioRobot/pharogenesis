enclosingPane
	"The object that owns this script layout"

	| oo higher |
	oo _ self owner.
	[higher _ oo isSyntaxMorph.
	higher _ higher or: [oo class == TransformMorph].
	higher _ higher or: [oo class == TwoWayScrollPane].
	higher ifFalse: [^ oo].
	higher] whileTrue: [oo _ oo owner].
