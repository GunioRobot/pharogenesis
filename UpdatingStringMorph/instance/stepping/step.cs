step

	| s |
	hasFocus ifFalse:
		["update contents, but only if user isn't editing this string"
		s _ self readFromTarget.
		s = contents ifFalse: [self contentsClipped: s]].
