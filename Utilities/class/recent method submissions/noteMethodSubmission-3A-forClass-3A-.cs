noteMethodSubmission: selectorName forClass: class
	| submission className |
	class wantsChangeSetLogging ifFalse: [^ self].
	className _ class name.
	self purgeRecentSubmissionsOfMissingMethods.
	submission _ className asString, ' ', selectorName.
	(self recentMethodSubmissions includes: submission)
		ifTrue: [RecentSubmissions remove: submission]
		ifFalse: [(RecentSubmissions size >= self numberOfRecentSubmissionsToStore) 
					ifTrue: [RecentSubmissions removeFirst]].
	RecentSubmissions addLast: submission