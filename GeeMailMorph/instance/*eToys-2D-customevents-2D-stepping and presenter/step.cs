step
	"For each submorph of thePasteUp that has just been scrolled into view, fire the script named #scrolledIntoView, if any.
	For each submorph of thePasteUp that has just been scrolled out of view, fire the script named #scrolledOutOfView, if any."
	| lastVisible nowVisible newlyVisible newlyInvisible |
	super step.
	lastVisible _ self visibleMorphs.
	nowVisible _ (thePasteUp submorphs copyWithoutAll: (self allTextPlusMorphs))
		select: [ :m | self bounds intersects: (m boundsIn: self world) ].
	newlyInvisible _ lastVisible difference: nowVisible.
	newlyInvisible do: [ :ea | ea triggerEvent: #scrolledOutOfView ].
	newlyVisible _ nowVisible difference: lastVisible.
	newlyVisible do: [ :ea | ea triggerEvent: #scrolledIntoView ].
	self visibleMorphs: nowVisible.
	