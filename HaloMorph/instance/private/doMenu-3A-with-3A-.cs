doMenu: evt with: menuHandle
	"Ask hand to invoke the halo menu for my inner target."

	| menu |
	self removeAllHandlesBut: nil.  "remove all handles"
	self world doOneCycle.
	menu _ evt hand buildMorphHandleMenuFor: innerTarget.
	menu addTitle: innerTarget externalName.
	evt hand invokeMenu: menu event: evt.
