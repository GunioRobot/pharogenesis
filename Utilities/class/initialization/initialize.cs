initialize
	RecentSubmissions := OrderedCollection new.
	self registerInFlapsRegistry.

	(TheWorldMenu respondsTo: #registerOpenCommand:) ifTrue: [
		TheWorldMenu registerOpenCommand: {'Recent Submissions'. {self. #browseRecentSubmissions}}]