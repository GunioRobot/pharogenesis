nextLineCrLf
	| nextLine |
	nextLine _ self upToAll: String crlf.
	^nextLine