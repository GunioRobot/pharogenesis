windowFromMenu: aMenu target: aTarget title: aTitle
	| n labelList colorPattern targetList selectionList |
	"Utilities windowFromMenu: ScheduledControllers screenController helpMenu target: ScheduledControllers screenController title: 'Help'"

	n _ aMenu selections size.

	labelList _ (1 to: n) asArray  collect:
		[:ind | aMenu labelString lineNumber: ind].

	colorPattern _ #(lightRed lightGreen lightBlue lightYellow lightGray).
			
	targetList _  (1 to: n) asArray  collect: [:ind | aTarget].
	selectionList _ aMenu selections.

	self windowMenuWithLabels:  labelList colorPattern: colorPattern targets: targetList selections: selectionList title: aTitle