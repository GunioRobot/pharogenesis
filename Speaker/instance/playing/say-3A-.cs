say: aString
	| events stream string |
	events _ CompositeEvent new.
	stream _ ReadStream on: (aString findTokens: '?' keep: '?').
	[stream atEnd]
		whileFalse: [string _ stream next.
					stream atEnd ifFalse: [string _ string, stream next].
					events addAll: (self eventsFromString: string)].
	events playOn: self voice delayed: events duration * 1000.
	self voice flush