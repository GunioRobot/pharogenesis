queryPointer: aX11Window
	| root child rootX rootY winX winY mask |
	root _ X11Window display: self.
	child _ X11Window display: self.
	rootX _ WordArray new: 1.
	rootY _ WordArray new: 1.
	winX _ WordArray new: 1.
	winY _ WordArray new: 1.
	mask _ WordArray new: 1.
	self XQueryPointer: self window: aX11Window returnRoot: root child: child
		rootX: rootX rootY: rootY winX: winX winY: winY mask: mask.
	^{root. child. rootX first @ rootY first. winX first @ winY first. mask first}