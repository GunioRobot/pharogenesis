recolorTabs
	"Prompt the user for new on and off colors for tabs"

	| onColor offColor |
	self inform: 'Choose the ''on'' color'.
	onColor _ Color fromUser.

	self inform: 
'Okay, now please choose
the ''off'' color'.
	offColor _ Color fromUser.

	tabsMorph highlightColor: onColor regularColor: offColor.
	currentPage ifNotNil:
		[tabsMorph highlightTabFor: currentPage]