linkMorphForMap: map andBrowser: browser
	| m |
	(m _ self buildMorph) ifNil: [^nil].
	m color: (Color random alpha: 0.1). "hack to ensure the morph is clickable"
	m
		on: #mouseUp
		send: #mouseUpEvent:linkMorph:browserAndUrl:
		to: map
		withValue: {browser. self href}.
	^m