fullBounds
	"This is the hook that triggers lazy re-layout of layout morphs. It works because layoutChanged clears the fullBounds cache. Once per cycle, the fullBounds is requested from every morph in the world, and that request gets propagated through the entire submorph hierarchy, causing re-layout where needed. Note that multiple layoutChanges to the same morph can be done with little cost, since the layout is only done when the morph needs to be displayed."

	fullBounds ifNil: [
		self resizeIfNeeded.
		self fixLayout.
		super fullBounds.  "updates cache"
		priorFullBounds == nil
			ifTrue: [self invalidRect: fullBounds]
			ifFalse: [fullBounds = priorFullBounds
					ifFalse: ["report change due to layout"
							self invalidRect: (fullBounds merge: priorFullBounds)]].
		layoutNeeded _ false].
	^ super fullBounds
