getSmoothingLevel
	"Menu support"
	| aaLevel |
	aaLevel := self defaultAALevel
				ifNil: [1].
	aaLevel = 1
		ifTrue: [^ 'turn on smoothing' translated].
	aaLevel = 2
		ifTrue: [^ 'more smoothing' translated].
	aaLevel = 4
		ifTrue: [^ 'turn off smoothing' translated]