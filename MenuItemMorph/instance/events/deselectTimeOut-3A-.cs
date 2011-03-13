deselectTimeOut: evt
	"Deselect timout. Now really deselect"
	owner selectedItem == self ifTrue:[owner selectItem: nil event: evt].