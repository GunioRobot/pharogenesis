player
	| renderee |
	"Distasteful hack, done because DropShadowMorph doesn't typically assume control of the player the way other renderers do."
	^ (renderee _ self renderedMorph) == self
		ifFalse:
			[renderee player ifNil: [super player]]
		ifTrue:
			[super player]