nextUpToAll: delimitingString
	| string |
	self unpeek.
	string _ self stream upToAll: delimitingString.
	self stream skip: delimitingString size negated.
	(self stream next: delimitingString size) = delimitingString
		ifFalse: [self parseError: 'XML no delimiting ' , delimitingString printString , ' found'].
	^string
