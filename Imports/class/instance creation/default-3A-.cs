default: anImports
	"Set my default instance. Returns the old value if any."
	| old |
	old _ default.
	default _ anImports.
	^old