getInputFocus
	| focus revert |
	focus _ X11Window new.
	focus display: self.
	revert _ WordArray new: 1.
	self XGetInputFocus: self with: focus with: revert.
	^focus