doDebug: evt with: menuHandle
	"Ask hand to invoke the a debugging menu for my inner target.  If shift key is down, immediately put up an inspector on the inner target"

	| menu |
	self removeAllHandlesBut: nil.  "remove all handles"
	self world displayWorld.
	evt shiftPressed ifTrue: 
		[self delete.
		^ innerTarget inspectInMorphic].

	menu _ evt hand buildDebugHandleMenuFor: innerTarget.
	menu addTitle: innerTarget externalName.
	evt hand invokeMenu: menu event: evt.
