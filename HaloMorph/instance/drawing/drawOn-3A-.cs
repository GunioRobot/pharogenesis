drawOn: aCanvas
	"Draw this morph only if it has no target."

	target ifNil: [super drawOn: aCanvas].
