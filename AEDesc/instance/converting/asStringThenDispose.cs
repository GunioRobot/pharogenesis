asStringThenDispose

	| string |
	string _ self asString.
	self dispose.
	^string