getFirstBuffer
	"Get the first source buffer after initialization has been done"
	sourceStream == nil ifTrue:[^self].
	source _ sourceStream next: 1 << 16. "This is more than enough..."
	sourceLimit _ source size.