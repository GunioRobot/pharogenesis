drawOn: aCanvas
	"Draw this morph only if it has no target."
	target ifNil: [super drawOn: aCanvas].
	"bordering commented out per Alan's request"
	"growingOrRotating" false ifTrue:
		["Show border if not otherwise visble during grow and rotate"
		((target isKindOf: BorderedMorph) and: [target borderWidth > 0]) ifFalse:
			[aCanvas frameRectangle: target bounds width: 1 color: Color black]]