getInputFocus
	| focus revert |
	focus _ X11Window display: self.
	revert _ WordArray new: 1.
	self XGetInputFocus: self with: focus with: revert.
	^focus