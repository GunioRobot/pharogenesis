copySameFrom: otherObject
	"Copy to myself all instance variables named the same in otherObject.
	This ignores otherObject's control over its own inst vars."

	| myInstVars otherInstVars match |
	myInstVars _ self class allInstVarNames.
	otherInstVars _ otherObject class allInstVarNames.
	myInstVars doWithIndex: [:each :index |
		(match _ otherInstVars indexOf: each) > 0 ifTrue:
			[self instVarAt: index put: (otherObject instVarAt: match)]].
	1 to: (self basicSize min: otherObject basicSize) do: [:i |
		self basicAt: i put: (otherObject basicAt: i)].
