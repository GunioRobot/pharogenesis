readFromTarget
	"Update my readout from my target"

	| v |
	(target isNil or: [getSelector isNil]) ifTrue: [^contents].
	self checkTarget.
	v := target perform: getSelector.	"scriptPerformer"
	(v isKindOf: Text) ifTrue: [v := v asString].
	^self acceptValueFromTarget: v