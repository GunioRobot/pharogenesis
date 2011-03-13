doDebug: evt with: menuHandle
	"Ask hand to invoke the a debugging menu for my inner target.  If shift key is down, immediately put up an inspector on the inner target"

	| menu |
	evt hand obtainHalo: self.
	self removeAllHandlesBut: nil.  "remove all handles"
	self world displayWorld.
	evt shiftPressed ifTrue: 
		[self delete.
		^ innerTarget inspectInMorphic: evt].

	menu _ innerTarget buildDebugMenu: evt hand.
	menu addTitle: innerTarget externalName.
	menu popUpEvent: evt in: self world.
