doMenu: evt with: menuHandle
	"Ask hand to invoke the halo menu for my target."

	| menu |
	self removeAllHandlesBut: nil.  "supp"
	self world doOneCycle.
	menu _ evt hand buildMorphHandleMenuFor: target.
	menu addTitle: target externalName.
	evt hand invokeMenu: menu event: evt.
