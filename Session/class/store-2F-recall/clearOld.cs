clearOld
	| aSession |
	Sessions keys do: [:s |
	aSession := Sessions at: s ifAbsent: [nil].
	aSession isNil ifFalse:
		[aSession isViable ifFalse: [self retire: s].]]