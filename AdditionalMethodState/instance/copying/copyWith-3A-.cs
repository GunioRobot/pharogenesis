copyWith: aPropertyOrPragma "<Association|Pragma>"
	"Answer a copy of the receiver which includes aPropertyOrPragma"
	| bs copy |
	(Association == aPropertyOrPragma class
	 or: [Pragma == aPropertyOrPragma class]) ifFalse:
		[self error: self class name, ' instances should hold only Associations or Pragmas.'].
	copy := self class new: (bs := self basicSize) + 1.
	1 to: bs do:
		[:i|
		copy basicAt: i put: (self basicAt: i)].
	copy basicAt: bs + 1 put: aPropertyOrPragma.
	^copy
		selector: selector;
		setMethod: method;
		yourself
