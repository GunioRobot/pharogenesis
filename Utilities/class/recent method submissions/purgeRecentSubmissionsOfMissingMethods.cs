purgeRecentSubmissionsOfMissingMethods
	"Utilities purgeRecentSubmissionsOfMissingMethods"

	| result |
	RecentSubmissions _ RecentSubmissions select:
		[:aSubmission |
			Utilities setClassAndSelectorFrom: aSubmission in: 
				[:aClass :aSelector |
					result _ aClass notNil and: [(aClass compiledMethodAt: aSelector ifAbsent: [nil]) notNil]].
			result]