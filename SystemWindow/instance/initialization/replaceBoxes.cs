replaceBoxes
	"Rebuild the various boxes."
	self setLabelWidgetAllowance.
	closeBox ifNotNilDo: [ :m | m delete. self addCloseBox. ].
	expandBox ifNotNilDo: [ :m | m delete. self addExpandBox. ].
	menuBox ifNotNilDo: [ :m | m delete. self addMenuControl. ].
	collapseBox ifNotNilDo: [ :m | m delete. labelArea addMorph: (collapseBox := self createCollapseBox) ].
	self setFramesForLabelArea.
	self setWindowColor: self paneColor 