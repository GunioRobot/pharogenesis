testInstanceCreation

	| warn |
	warn _ Preferences showDeprecationWarnings.
	Preferences setPreference: #showDeprecationWarnings toValue: true.
	
	self 
		should: [ self timestampClass midnight asDuration = (0 hours) ];
		should: [ self timestampClass midnightOn: timestamp date ] 
			raise: Deprecation;
		should: [ self timestampClass noon asDuration = (12 hours) ];
		should: [ self timestampClass noonOn: timestamp date ] 
			raise: Deprecation.
			
	Preferences setPreference: #showDeprecationWarnings toValue: warn.
