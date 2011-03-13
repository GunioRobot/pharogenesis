savePreferencesFor: aService 
	| strm |
	"pref := ServicePreferences preferenceAt: aService shortcutPreference.
	strm := WriteStream with: ''.
	strm nextPutAll: aService id;
		 nextPutAll: 'shortcut';
		 cr;
		 tab;
		 nextPutAll: '^ ';
		 nextPutAll: {pref name. pref preferenceValue. 1000} storeString.
	self class compileSilently: strm contents classified: 'saved preferences'."
	aService isCategory
		ifTrue: [aService externalPreferences
				doWithIndex: [:e :i | 
					strm := WriteStream with: aService id asString.
					strm nextPutAll: e id asString;
						 cr;
						 tab;
						 nextPutAll: '^ ';
						 nextPutAll: {aService childrenPreferences. e id. i} storeString.
					e provider class compileSilently: strm contents classified: 'saved preferences']]