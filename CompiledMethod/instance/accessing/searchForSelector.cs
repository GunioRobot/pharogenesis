searchForSelector
	"search me in all classes, if found, return my selector. Slow!"
	| selector |
	self systemNavigation allBehaviorsDo: [:class | 
		(selector := class methodDict keyAtIdentityValue: self ifAbsent: [nil]) ifNotNil: [^selector]].
	^nil.