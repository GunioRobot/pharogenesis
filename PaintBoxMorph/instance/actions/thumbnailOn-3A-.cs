thumbnailOn: aMorph
	"Try to show mineature of this guy.  5/5/97 tk   Not used now."

	(aMorph isKindOf: SketchMorph) ifTrue: [
		thumbnail morphToView: aMorph.
		thumbnail step.
		self invalidRect: thumbnail bounds].
	