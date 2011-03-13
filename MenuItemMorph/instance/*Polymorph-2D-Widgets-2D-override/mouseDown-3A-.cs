mouseDown: evt
	"Handle a mouse down event. Menu items get activated when the mouse is over them."

	evt shiftPressed ifTrue: [^ super mouseDown: evt].  "enable label editing" 

	"Quick hack to bring menu to the front if it is obscured. See 
		http://bugs.squeak.org/view.php?id=1780" "fixed by gvc to work with embedded menus"
	self owner owner = self world ifTrue: [
		self world morphsInFrontOf: self owner overlapping: self owner bounds
			do: [:ignored | ^ self owner comeToFront]].

	(self isInDockingBar
			and:[isSelected]
			"and:[owner selectedItem == self]")
		ifTrue:[
			evt hand newMouseFocus: nil.
			owner selectItem: nil event: evt. ]
		ifFalse:[
			evt hand newMouseFocus: owner. "Redirect to menu for valid transitions"
			owner selectItem: self event: evt. ]
