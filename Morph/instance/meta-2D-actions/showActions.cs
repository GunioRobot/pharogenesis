showActions
	"Put up a message list browser of all the code that this morph  
	would run for mouseUp, mouseDown, mouseMove, mouseEnter,  
	mouseLeave, and  
	mouseLinger. tk 9/13/97"
	| list cls selector adder |
	list _ SortedCollection new.
	adder _ [:mrClass :mrSel | list
				add: (MethodReference new setStandardClass: mrClass methodSymbol: mrSel)].
	"the eventHandler"
	self eventHandler
		ifNotNil: [list _ self eventHandler methodRefList.
			(self eventHandler handlesMouseDown: nil)
				ifFalse: [adder value: HandMorph value: #grabMorph:]].
	"If not those, then non-default raw events"
	#(#keyStroke: #mouseDown: #mouseEnter: #mouseLeave: #mouseMove: #mouseUp: #doButtonAction )
		do: [:sel | 
			cls _ self class whichClassIncludesSelector: sel.
			cls
				ifNotNil: ["want more than default behavior"
					cls == Morph
						ifFalse: [adder value: cls value: sel]]].
	"The mechanism on a Button"
	(self respondsTo: #actionSelector)
		ifTrue: ["A button"
			selector _ self actionSelector.
			cls _ self target class whichClassIncludesSelector: selector.
			cls
				ifNotNil: ["want more than default behavior"
					cls == Morph
						ifFalse: [adder value: cls value: selector]]].
	MessageSet openMessageList: list name: 'Actions of ' , self printString