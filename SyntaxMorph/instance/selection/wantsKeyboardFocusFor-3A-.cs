wantsKeyboardFocusFor: aSubmorph
	| doEdit |
	"only let strings edit on shift-click.  Editing on ordinary click defeats the brown selection and tile dragging."

	doEdit _ self world primaryHand lastEvent shiftPressed.
	doEdit ifTrue: ["remove the arrows during editing"
		self valueOfProperty: #myPopup ifPresentDo: [:panel |
			panel delete. self removeProperty: #myPopup]].
	^ doEdit