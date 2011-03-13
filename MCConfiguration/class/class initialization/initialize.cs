initialize
	"MCConfiguration initialize"

	Preferences addPreference: #upgradeIsMerge
		categories: #('updates') default: false 
		balloonHelp: 'When upgrading packages, use merge instead of load'.