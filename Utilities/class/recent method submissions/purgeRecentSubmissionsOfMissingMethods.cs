purgeRecentSubmissionsOfMissingMethods
	"Utilities purgeRecentSubmissionsOfMissingMethods"

	| keep |
	self flag: #mref.	"fix for faster references to methods"
	RecentSubmissions _ RecentSubmissions select:
		[:aSubmission | 
			Utilities setClassAndSelectorFrom: aSubmission in:
				[:aClass :aSelector |
					keep _ (aClass == nil) not
						and: [aClass isInMemory
						and: [aSelector == #Comment or: [(aClass compiledMethodAt: aSelector ifAbsent: [nil]) notNil]]]].
			keep]