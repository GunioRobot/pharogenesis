addYellowButtonMenuItemsTo: aCustomMenu event: evt
	"Populate aCustomMenu with appropriate menu items for a yellow-button (context menu) click."

	aCustomMenu
		defaultTarget: self;
		addStayUpItem.
	self addModelYellowButtonItemsTo: aCustomMenu event: evt