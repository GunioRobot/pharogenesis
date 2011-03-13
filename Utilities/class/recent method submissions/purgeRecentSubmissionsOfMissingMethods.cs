purgeRecentSubmissionsOfMissingMethods
	"Utilities purgeRecentSubmissionsOfMissingMethods"

	| keep |
	RecentSubmissions := RecentSubmissions select:
		[:aSubmission | 
			Utilities setClassAndSelectorFrom: aSubmission in:
				[:aClass :aSelector |
					keep := aClass notNil
						and: [aClass isInMemory
						and: [aSelector == #Comment or: [(aClass compiledMethodAt: aSelector ifAbsent: [nil]) notNil]]]].
			keep]