sliderColor: aColor 
	"Change the color of the scrollbar to go with aColor."
	| buttonColor |
	super sliderColor: aColor.
	buttonColor := self thumbColor.
	menuButton
		ifNotNil: [menuButton color: buttonColor].
	upButton color: buttonColor.
	downButton color: buttonColor.
	slider color: buttonColor slightlyLighter.
	
	self class updateScrollBarButtonsAspect: {menuButton. upButton. downButton} color: buttonColor.
	
	self updateMenuButtonImage.
	self updateUpButtonImage.
	self updateDownButtonImage.
	
	self roundedScrollbarLook
				ifTrue: [
					self color: Color transparent.
					pagingArea color: aColor muchLighter.
					self borderStyle style == #simple
						ifTrue: [self borderColor: aColor darker darker]
						ifFalse: [self borderStyle baseColor: aColor]]
				ifFalse: [
					pagingArea
						color: (aColor alphaMixed: 0.3 with: Color white).
					self borderWidth: 0]