deselectTimeOut: evt
	"Deselect timout. Now really deselect"
	owner selectedItem == self
		ifTrue:[
			evt hand newMouseFocus: nil.
			owner selectItem: nil event: evt].
