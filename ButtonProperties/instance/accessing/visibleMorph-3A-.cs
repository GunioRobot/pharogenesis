visibleMorph: x

	visibleMorph ifNotNil: [self setEventHandlers: false].
	visibleMorph _ x.
	visibleMorph ifNotNil: [self setEventHandlers: true].
