invokeAt: aPoint in: aWorld
	"Add this menu to the given world centered at the given point. Wait for the user to make a selection and answer it. The selection value returned is an integer in keeping with PopUpMenu, if the menu is converted from an MVC-style menu."
	"Details: This is invoked synchronously from the caller. In order to keep processing inputs and updating the screen while waiting for the user to respond, this method has its own version of the World's event loop."
	| h |
	h _ aWorld activeHand.
	h ifNil: [h _ aWorld hands first].
	self popUpAt: aPoint forHand: h.
	done _ false.
	[self isInWorld & done not] whileTrue: [aWorld doOneCycle].
	self delete.
	^ selectedItem
