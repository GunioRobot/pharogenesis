mouseMove: evt
	"Make handle track the cursor within my bounds."

	| m r center |
	m _ handleMorph.
	center _ m center.
	r _ m owner innerBounds insetBy:
		((center - m fullBounds origin) corner: (m fullBounds corner - center)).
	m position: (evt cursorPoint adhereTo: r) - (m extent // 2).
