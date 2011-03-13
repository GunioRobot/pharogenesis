reportableSize
	"Answer a size worth reporting as the receiver's size in a list view"

	| total |
	total _ super reportableSize.
	submorphs do:
		[:m | total _ total + m reportableSize].
	^ total