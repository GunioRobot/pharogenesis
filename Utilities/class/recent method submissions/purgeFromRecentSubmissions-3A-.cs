purgeFromRecentSubmissions: aMethodReference
	"Purge any reference found in RecentSubmissions to the method supplied"

	RecentSubmissions _ RecentSubmissions select:
		[:aSubmission |
			Utilities setClassAndSelectorFrom: aSubmission in:
				[:aClass :aSelector | (aClass ~~ aMethodReference actualClass) or: [aSelector ~~ aMethodReference methodSymbol]]]