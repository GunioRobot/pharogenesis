drawSubmorphsOn: aCanvas 
	"Display submorphs back to front.
	Draw the focus here since we are using inset bounds
	for the focus rectangle."

	super drawSubmorphsOn: aCanvas.
	self hasKeyboardFocus ifTrue: [
		self selectedTab ifNotNilDo: [:t |
			self clipSubmorphs 
				ifTrue: [aCanvas
							clipBy: (aCanvas clipRect intersect: self clippingBounds)
							during: [:c | t drawKeyboardFocusOn: c]]
				ifFalse: [t drawKeyboardFocusOn: aCanvas]]]