adoptGradientColor: aColor
	"Adopt the given pane color."

	|c fs bfs bs bbs|
	aColor ifNil:[^self].
	c := aColor.
	fs := self normalThumbFillStyle.
	bfs := self normalButtonFillStyle.
	bs := self normalThumbBorderStyle.
	bbs := self normalButtonBorderStyle.
	sliderColor := c.
	downButton
		fillStyle: bfs;
		borderStyle: bbs.
	upButton
		fillStyle: bfs clone;
		borderStyle: bbs.
	slider
		fillStyle: fs;
		borderStyle: bs.
	menuButton ifNotNilDo: [:mb |
		mb
			fillStyle: bfs clone;
		borderStyle: bbs].
	self updateMenuButtonImage.
	self updateUpButtonImage.
	self updateDownButtonImage