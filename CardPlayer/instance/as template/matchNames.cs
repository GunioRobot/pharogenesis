matchNames
	| list str ll tms stk crds |
	"List of names of cards that matched the last template search."

	tms _ self class classPool at: #TemplateMatches ifAbsent: [^ #()].
	list _ (tms at: self ifAbsent: [#(#() 0)]) first.
	stk _ costume valueOfProperty: #myStack ifAbsent: [nil].
	crds _ stk ifNil: [#()] ifNotNil: [stk cards].
	^ list collect: [:cd | 
		str _ ''.
		(ll _ cd allStringsAfter: nil) ifNotNil: [
			str _ ll inject: '' into: [:strr :this | strr, this]]. 
		(str copyFrom: 1 to: (30 min: str size)), '...  (' , (crds indexOf: cd) printString, ')'].
		"Maybe include a card title?"