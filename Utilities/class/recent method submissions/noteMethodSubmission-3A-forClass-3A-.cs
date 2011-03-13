noteMethodSubmission: selectorName forClass: className
	| aSubmission |
	aSubmission _ className asString, ' ', selectorName.
	(self recentMethodSubmissions includes: aSubmission)
		ifTrue:
			[RecentSubmissions remove: aSubmission]
		ifFalse:
			[(RecentSubmissions size >= self numberOfRecentSubmissionsToStore) 
				ifTrue: [RecentSubmissions removeFirst]].
	RecentSubmissions addLast: aSubmission