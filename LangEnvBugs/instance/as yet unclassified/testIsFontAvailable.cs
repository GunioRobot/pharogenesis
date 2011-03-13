testIsFontAvailable
"self new testIsFontAvailable"
"self run: #testIsFontAvailable"
| oldPref |

oldPref := Preferences valueOfPreference: #tinyDisplay .

Preferences enable: #tinyDisplay .

self shouldnt: [ [ ( LanguageEnvironment localeID: 'en' ) isFontAvailable ] 
					ensure: [Preferences setPreference: #tinyDisplay toValue: oldPref] ] 
	raise: Error.
^true