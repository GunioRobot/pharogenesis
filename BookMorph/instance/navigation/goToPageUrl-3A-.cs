goToPageUrl: aUrl

	| pp short |
	pp _ pages detect: [:pg | pg url = aUrl] ifNone: [nil].
	pp ifNil: [short _ (aUrl findTokens: '/') last.
			pp _ pages detect: [:pg | pg url ifNil: [false]
						ifNotNil: [(pg url findTokens: '/') last = short]] "it moved"
					ifNone: [pages at: 1]].
	self goToPageMorph: pp.
