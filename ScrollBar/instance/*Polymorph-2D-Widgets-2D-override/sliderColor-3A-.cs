sliderColor: aColor 
	"Change the color of the scrollbar to go with aColor."
	| buttonColor |
	super sliderColor: aColor.
	self setProperty: #lastPaneColor toValue: aColor.
	buttonColor := self thumbColor.
	menuButton
		ifNotNil: [menuButton color: buttonColor].
	upButton color: buttonColor.
	downButton color: buttonColor.
	slider color: buttonColor slightlyLighter.
	
	Preferences gradientScrollbarLook ifFalse: [
		self class updateScrollBarButtonsAspect: {menuButton. upButton. downButton} color: buttonColor.
		self updateMenuButtonImage.
		self updateUpButtonImage.
		self updateDownButtonImage].
	
	pagingArea
		fillStyle: self normalFillStyle;
		borderStyle: self normalBorderStyle.
	(self theme scrollbarPagingAreaCornerStyleIn: self window) = #rounded
		ifTrue: [self fillStyle: self normalButtonFillStyle]
		ifFalse: [self fillStyle: self normalFillStyle].
	self borderWidth: 0.
	Preferences gradientScrollbarLook ifTrue: [^self adoptGradientColor: aColor]