escapeToDesktop: characterStream 
	"Pop up a morph to field keyboard input in the context of the desktop"

	Smalltalk isMorphic ifTrue: [ActiveWorld putUpWorldMenuFromEscapeKey].
	^ true