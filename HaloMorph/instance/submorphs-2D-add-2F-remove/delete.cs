delete
	"Delete the halo.  Tell the target that it no longer has the halo; accept any pending edits to the name; and then either actually delete myself or start to fade out"

	target ifNotNil:
		[target hasHalo: false].
	self acceptNameEdit.
	self isMagicHalo: false.
	Preferences haloTransitions
		ifTrue:
			[self stopStepping; startStepping.
			self startSteppingSelector: #fadeOutFinally]
		ifFalse:
			[super delete]