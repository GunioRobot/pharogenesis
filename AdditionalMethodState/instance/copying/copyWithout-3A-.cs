copyWithout: aPropertyOrPragma "<Association|Pragma>"
	"Answer a copy of the receiver which no longer includes aPropertyOrPragma"
	| bs copy offset |
	copy := self class new: (bs := self basicSize) - ((self includes: aPropertyOrPragma)
													ifTrue: [1]
													ifFalse: [0]).
	offset := 0.
	1 to: bs do:
		[:i|
		(self basicAt: i) = aPropertyOrPragma
			ifTrue: [offset := 1]
			ifFalse: [copy basicAt: i - offset put: (self basicAt: i)]].
	^copy
		selector: selector;
		setMethod: method;
		yourself
