inMorphicWindowLabeled: labelString
	"Answer a morphic window with the given label that can display the receiver"

	| window listFraction |
	window _ (SystemWindow labelled: labelString) model: self.
	listFraction _ 0.2.
	window addMorph: self buildMorphicMessageList frame: (0@0 extent: 1@listFraction).
	self 
		addLowerPanesTo: window 
		at: (0@listFraction corner: 1@1) 
		with: nil.

	window setUpdatablePanesFrom: #(messageList).
	^ window