fillingOnOff
	"Establish a container for this text, with opposite filling status"
	self setContainer:
	(container
		ifNil: [TextContainer new for: self minWidth: textStyle lineGrid*2]
		ifNotNil: [(container fillsOwner and: [container avoidsOcclusions not])
			ifTrue: [nil  "Return to simple rectangular bounds"]
			ifFalse: [container fillsOwner: container fillsOwner not]])