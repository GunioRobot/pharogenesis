testIsFontAvailable
	"self debug: #testIsFontAvailable"
	(Locale isoLanguage: 'ja') languageEnvironment removeFonts.
	self assert: (Locale isoLanguage: 'en') languageEnvironment isFontAvailable.
	"Next test should fail after installing Japanese font"
	self assert: (Locale isoLanguage: 'ja') languageEnvironment isFontAvailable not.
	(Locale isoLanguage: 'ja') languageEnvironment installFont.
	self assert: (Locale isoLanguage: 'ja') languageEnvironment isFontAvailable