noteMethodSubmission: selectorName forClass: class

	| submission |

	self flag: #mref.	"fix for faster references to methods"

	self recentMethodSubmissions.	"ensure it is valid"
	class wantsChangeSetLogging ifFalse: [^ self].
	self purgeRecentSubmissionsOfMissingMethods.
	submission _ class name asString, ' ', selectorName.
	RecentSubmissions removeAllSuchThat: [ :each |
		each asStringOrText = submission
	].
	RecentSubmissions size >= self numberOfRecentSubmissionsToStore ifTrue: [
		RecentSubmissions removeFirst
	].
	RecentSubmissions addLast: (
		MethodReference new
			setClass: class 
			methodSymbol: selectorName 
			stringVersion: submission
	) 
