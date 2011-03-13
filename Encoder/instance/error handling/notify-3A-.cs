notify: string
	"Put a separate notifier on top of the requestor's window"
	| req |
	requestor == nil
		ifFalse: 
			[req _ requestor.
			self release.
			req notify: string].
	^false