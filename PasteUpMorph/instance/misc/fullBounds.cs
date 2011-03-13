fullBounds
	"This is the hook that triggers lazy re-layout. See the comment in LayoutMorph."

	| result |
	(fullBounds == nil and: [self autoLineLayout]) ifTrue:
		[self fixLayout.
		"compute fullBounds before calling changed to avoid infinite recursion!"
		result _ super fullBounds.  "updates cache"
		self changed.
		^ result].
	self resizeToFit ifFalse: [^ bounds].
	^ super fullBounds
