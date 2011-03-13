testRevert
	gofer load.
	self assert: (self evaluate: #BogusA selector: #isFake).
	self compile: #BogusA method: 'isFake ^ false'.
	self deny: (self evaluate: #BogusA selector: #isFake).
	self shouldnt: [ gofer revert ] raise: Error.
	self assert: (self evaluate: #BogusA selector: #isFake)