doMenuItem: selector paneID: textSelector from: aController
	"Selector was just chosen from a menu by a user.  If I want to respond, perform it on myself. If not, make aController perform it.   textSelector is what I told the pluggable pane to ask me to get the contents of this pane, here so I can identify which pane is was." 

	"default is that the controller does all!"
	aController perform: selector