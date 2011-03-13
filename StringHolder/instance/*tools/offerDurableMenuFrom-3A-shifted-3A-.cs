offerDurableMenuFrom: menuRetriever shifted: aBoolean
	"Pop up (morphic only) a menu whose target is the receiver and whose contents are provided by sending the menuRetriever to the receiver.  The menuRetriever takes two arguments: a menu, and a boolean representing the shift state; put a stay-up item at the top of the menu."

	| aMenu |
	aMenu := MenuMorph new defaultTarget: self.
	aMenu addStayUpItem.
	self perform: menuRetriever with: aMenu with: aBoolean.
		aMenu popUpInWorld