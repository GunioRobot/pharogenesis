notify: string at: location

	| req |
	requestor == nil
		ifFalse: 
			[req _ requestor.
			self release.
			req notify: string at: location].
	^false