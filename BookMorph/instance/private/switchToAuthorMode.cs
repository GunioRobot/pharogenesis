switchToAuthorMode
	"Replace the control panel with one specially for authoring"
	
	self deleteControls.
	self addMorph: ((self makeAuthoringPageControlsColored: self color lighter) borderWidth: 1; inset: 4)

