delete
	"Remove the receiver as a submorph of its owner and make its 
	new owner be nil."

	| aWorld |
	aWorld := self world ifNil: [World].
	"Terminate genie recognition focus"
	"I encountered a case where the hand was nil, so I put in a little 
	protection - raa "
	" This happens when we are in an MVC project and open
	  a morphic window. - BG "
	aWorld ifNotNil:
	  [self disableSubmorphFocusForHand: self activeHand.
	  self activeHand releaseKeyboardFocus: self;
		  releaseMouseFocus: self.].
	owner ifNotNil:[ self privateDelete.
		self player ifNotNilDo: [ :player |
			"Player must be notified"
			player noteDeletionOf: self fromWorld: aWorld]].