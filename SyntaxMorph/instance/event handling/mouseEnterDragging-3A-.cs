mouseEnterDragging: evt
	"Highlight this level as a potential drop target"

"Transcript cr; print: self; show: ' enterDragging'."
	evt hand hasSubmorphs ifFalse: [^ self].  "Don't react to empty hand"
	self unhighlightOwner.
	self highlightForDrop: evt.

	self isBlockNode ifTrue:
		[(self firstOwnerSuchThat: [:m | m isSyntaxMorph and: [m isBlockNode]])
			ifNotNilDo: [:m | "Suspend outer block."
						m stopStepping; removeDropZones].
		self startStepping]
