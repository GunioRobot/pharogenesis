initializeParameters
	"Preferences initializeParameters"
	Parameters _ IdentityDictionary new.
	self restoreDefaultMenuParameters.
	Parameters at: #maxBalloonHelpLineLength put: 28.
	self initializeTextHighlightingParameters