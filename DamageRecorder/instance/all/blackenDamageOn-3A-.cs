blackenDamageOn: aCanvas
	"For testing. Blackens the damaged rectangles momentarily so you can see the incremental redisplay at work."

	| c |
	invalidRects do: [:r |
		c _ aCanvas copyClipRect: r.
		c fillColor: Color black].
