methodHolderVersions
	| arrayOfVersions vTimes strings |
	"Create lists of times of older versions of all code in MethodMorphs in this book."

	arrayOfVersions _ MethodHolders collect: [:mh | 
		mh versions].	"equality, hash for MethodHolders?"
	vTimes _ SortedCollection new.
	arrayOfVersions do: [:versionBrowser |  
		versionBrowser changeList do: [:cr | 
			(strings _ cr stamp findTokens: ' ') size > 2 ifTrue: [
				vTimes add: strings second asDate asSeconds + 
						strings third asTime asSeconds]]].
	VersionTimes _ Time condenseBunches: vTimes.
	VersionNames _ Time namesForTimes: VersionTimes.
