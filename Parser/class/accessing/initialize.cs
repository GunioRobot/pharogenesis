initialize
	"self initialize"
	
	self doNotWarnUser.
	Preferences
		addBooleanPreference: #allowUnderscoreAssignment 
		category: #compiler 
		default: false
		balloonHelp: 'If enabled, the compiler will accept _ (underscore) for assignment.\This provides backward compatibility with the pre-ANSI compiler.' withCRs.
	Preferences
		addBooleanPreference: #allowBlockArgumentAssignment 
		category: #compiler 
		default: false
		balloonHelp: 'If enabled, the compiler will allow assignment into block arguments.\This provides backward compatibility with the pre-closure compiler.' withCRs.