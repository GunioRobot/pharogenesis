assureMostRecentSubmissionExists
	"Make certain that the most recent submission exists"

	[RecentSubmissions size > 0 and:
		[RecentSubmissions last isValid not]] whileTrue:
			[RecentSubmissions removeLast].