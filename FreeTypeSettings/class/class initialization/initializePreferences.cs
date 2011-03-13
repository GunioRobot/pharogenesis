initializePreferences
	"create preferences for all my settings if they are missing
	self initializePreferences
	"
	Preferences
		addBooleanPreference: #UpdateFontsAtImageStartup
		categories: {'FreeType'} 
		default: true 
		balloonHelp: 'Update font settings at image startup'.
	Preferences
		addBooleanPreference: #HintingFull
		categories: {'FreeType'}
		default: false
		balloonHelp: 'Changes glyph shapes so that their features are snapped to pixel boundaries. Glyphs are monochrome, with no anti-aliasing. This option changes the shapes the most.'
		projectLocal: false
		changeInformee: self
		changeSelector: #HintingFullPreferenceChanged.
	Preferences
		addBooleanPreference: #HintingNormal
		categories: {'FreeType'}
		default: false
		balloonHelp: 'Changes glyph shapes so that their features are snapped to pixel boundaries. Glyphs are anti-aliased'
		projectLocal: false
		changeInformee: self
		changeSelector: #HintingNormalPreferenceChanged.
	Preferences
		addBooleanPreference: #HintingLight
		categories: {'FreeType'}
		default: true
		balloonHelp: 'Changes glyph shapes so that their features are partially snapped to pixel boundaries. This option changes the shapes less than HintingFull, resulting in better shapes, but less contrast.'
		projectLocal: false
		changeInformee: self
		changeSelector: #HintingLightPreferenceChanged.
	Preferences
		addBooleanPreference: #HintingNone
		categories: {'FreeType'}
		default: false
		balloonHelp: 'Uses the original glyph shapes without snapping their features to pixel boundaries. This gives the best shapes, but with less contrast and more fuzziness.'
		projectLocal: false
		changeInformee: self
		changeSelector: #HintingNonePreferenceChanged.
	Preferences
		addPreference: #GlyphContrast
		categories: {'FreeType'}
		default: 50
		balloonHelp: 'Change the contrast level for glyphs. This is an integer between 1 and 100. (the default value is 50)'
		projectLocal: false
		changeInformee: self
		changeSelector: #GlyphContrastPreferenceChanged
		viewRegistry: (Smalltalk at: #PreferenceViewRegistry ifPresent:[:c | c ofNumericPreferences])  .
	Preferences
		addPreference: #FreeTypeCacheSize
		categories: {'FreeType'}
		default: 5000
		balloonHelp: 'The size of the cache in KBytes (default is 5000K)'
		projectLocal: false
		changeInformee: self
		changeSelector: #FreeTypeCacheSizePreferenceChanged
		viewRegistry:  (Smalltalk at: #PreferenceViewRegistry ifPresent:[:c | c ofNumericPreferences]) 