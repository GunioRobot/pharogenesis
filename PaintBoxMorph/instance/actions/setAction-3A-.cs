setAction: aSelector
	"Find this button and turn it on.  Does not work for stamps or pickups"

	| button |
	button _ self findButton: aSelector.
 
	button ifNotNil: [
		button state: #on.
		button doButtonAction].	"select it!"