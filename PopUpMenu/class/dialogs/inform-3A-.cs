inform: aString
	"PopUpMenu inform: 'I like Squeak'"

	(PopUpMenu labels: ' OK ' translated)
		startUpWithCaption: aString
		icon: MenuIcons confirmIcon
