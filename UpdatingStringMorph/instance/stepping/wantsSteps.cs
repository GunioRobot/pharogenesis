wantsSteps
	"Don't start me stepping if I have nothing to do."

	((target == nil) or: [getSelector == nil]) ifTrue: [^ false].
	^ super wantsSteps
