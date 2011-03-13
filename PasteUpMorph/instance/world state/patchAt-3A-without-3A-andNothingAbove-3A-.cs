patchAt: patchRect without: stopMorph andNothingAbove: stopThere
	"Return a complete rendering of this patch of the display screen
	without stopMorph, and possibly without anything above it."
	| c |
	c _ ColorPatchCanvas extent: patchRect extent depth: Display depth.
	c stopMorph: stopMorph.
	c doStop: stopThere.
	c _ c copyOrigin: patchRect topLeft negated clipRect: (0@0 extent: patchRect extent).
	(self bounds containsRect: patchRect) ifFalse:
		["Need to fill area outside bounds with black."
		c form fillColor: Color black].
	(self bounds intersects: patchRect) ifFalse:
		["Nothing within bounds to show."
		^ c form].
	c fillRectangle: self bounds color: color.  "Fill bounds with world color."
	self drawSubmorphsOn: c.
	worldState handsReverseDo: [:h | h drawSubmorphsOn: c].
	^c form
