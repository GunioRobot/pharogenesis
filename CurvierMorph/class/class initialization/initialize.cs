initialize
	"CurvierMorph initialize"
	Preferences
		preferenceAt: #Curvier
		ifAbsent: [Preferences
				addPreference: #Curvier
				category: #morphic
				default: true
				balloonHelp: 'if true, closed CurvierMorphs will be smoother and more symmetrical all about. If false they will mimic the old curve shapes with the one sharp bend.'].
	self registerInFlapsRegistry