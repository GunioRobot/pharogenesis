copyRecordingIn: dict
	"Overridden to copy the pages of this book as well."

	| new |
	new _ super copyRecordingIn: dict.
	new pages: (pages collect: [:pg |
		"the current page was copied with the submorphs"
		(dict includesKey: pg)
			ifTrue: [dict at: pg]  "current page; already copied"
			ifFalse: [pg copyRecordingIn: dict]]).
	^ new
