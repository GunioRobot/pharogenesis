showActions
	"Put up a message list browser of all the code that this morph
would run for mouseUp, mouseDown, mouseMove, mouseEnter, mouseLeave, and
mouseLinger.  tk 9/13/97"
	| list cls selector |
	"the eventHandler"
	self eventHandler ifNil: [list _ SortedCollection new]
			ifNotNil: [
				list _ self eventHandler messageList.
				(self eventHandler handlesMouseDown: nil) 
					ifFalse:[list add: 'HandMorph grabMorph:']].
	"If not those, then non-default raw events"
	#(keyStroke: mouseDown: mouseEnter: mouseLeave: mouseMove: mouseUp:
	doButtonAction)
		do: [:sel |
			cls _ self class classThatUnderstands: sel.
			cls ifNotNil: ["want more than default behavior"
				cls == Morph ifFalse: [list add: cls name, ' ',sel]]].
	"The mechanism on a Button"
	(self respondsTo: #actionSelector) ifTrue: ["A button"
		selector _ self actionSelector.
		cls _ self target class classThatUnderstands: selector.
			cls ifNotNil: ["want more than default behavior"
				cls == Morph ifFalse: [list add: cls name, ' ',selector]]].
	MessageSet openMessageList: list name: 'Actions of ', self printString.