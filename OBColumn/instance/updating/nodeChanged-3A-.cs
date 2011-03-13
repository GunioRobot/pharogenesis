nodeChanged: ann
	(children includes: ann node) ifTrue: [self changed: #list]