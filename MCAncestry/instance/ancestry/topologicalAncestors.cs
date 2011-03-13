topologicalAncestors
	| frontier f |
	^ Array streamContents:
		[:s |
		frontier := MCFrontier frontierOn: self.
		[f := frontier frontier.
		s nextPutAll: f.
		frontier removeAll: f.
		f isEmpty] whileFalse] 