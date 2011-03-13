fullBounds
	"This is the hook that triggers lazy re-layout of layout morphs. It works because layoutChanged clears the fullBounds cache. Once per cycle, the fullBounds is requested from every morph in the world, and that request gets propagated through the entire submorph hierarchy, causing re-layout where needed. Note that multiple layoutChanges to the same morph can be done with little cost, since the layout is only done when the morph needs to be displayed."

	fullBounds ifNil: [
		layoutNeeded ifTrue: [
			self resizeIfNeeded.
			self fixLayout.
			"compute fullBounds before calling changed to avoid infinite recursion"
			super fullBounds.  "updates cache"
			self changed.  "report change due to layout"
			layoutNeeded _ false]].
	^ super fullBounds
