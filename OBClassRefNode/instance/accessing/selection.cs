selection
	| start parser |
	(parser _ Compiler parserClass new) parseSelector: self source.
	start := parser endOfLastToken.
	start := (self source asString findString: className startingAt: start).
	^ start to: start + className size - 1