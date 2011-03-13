addPreference: name category: cat selector: sel
	
	ServicePreferences 
		 addPreference: name
		 categories: {cat asSymbol. self providerCategory}
		 default: ''
		 balloonHelp:self description
		 projectLocal:false
		 changeInformee: self id -> sel
		 changeSelector: #serviceUpdate
		 viewRegistry: PreferenceViewRegistry ofTextPreferences