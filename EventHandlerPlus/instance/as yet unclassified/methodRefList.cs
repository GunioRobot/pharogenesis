methodRefList
	"Return a MethodReference for each message I can send."
	
	|list adder|
	list := super methodRefList.
	adder := [:recip :sel | recip
				ifNotNil: [list
						add: (MethodReference new
								setStandardClass: (recip class whichClassIncludesSelector: sel)
								methodSymbol: sel)]].
	adder value: mouseOverRecipient value: mouseOverSelector.
	^list