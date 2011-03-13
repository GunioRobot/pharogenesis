initialize
	"Set up the editableStringMorphs preferences here to allow for restricting
	access in a deployed image."

	Preferences
		addPreference: #editableStringMorphs
		categories: #(morphic)
		default: false
		balloonHelp: 'Determines whether shift-clicking on a string morph will make the text editable.'