renderPhraseAccentOrBoundaryTone: aStringOrNil
	aStringOrNil isNil ifTrue: [^ self].
	(aStringOrNil findTokens: ' ') do: [ :each |
		each = 'H-' ifTrue: [self renderHighPhraseAccent].
		each = 'L-' ifTrue: [self renderLowPhraseAccent].
		each = 'H%' ifTrue: [self renderHighBoundary].
		each = 'L%' ifTrue: [self renderLowBoundary].
		each = '%H' ifTrue: [self renderHighInitial].
		each = '%r' ifTrue: [self notYetImplemented]]