fullBounds
	"This is the hook that triggers lazy re-layout. See the comment in LayoutMorph."

	fullBounds ifNil: [
		self fixLayout.
		"compute fullBounds before calling changed to avoid infinite recursion!"
		super fullBounds.  "updates cache"
		self changed].
	^ super fullBounds
