newTabs: tabsList
	"Reconstitute the palette based on info in the tabs list"

	| itsBook color1 color2 color3 |
	pages _ pages species new.
	tabsMorph ifNotNil:
		[color1 _ tabsMorph  highlightColor.
		color2 _ tabsMorph regularColor.
		color3 _ tabsMorph color.
		tabsMorph delete].
	tabsMorph _ IndexTabs new.
	self addMorphFront: tabsMorph.
	color1 ifNotNil:
		[tabsMorph highlightColor: color1 regularColor: color2; color: color3].
	currentPage ifNotNil:
		[currentPage delete.
		currentPage _ nil].
	tabsList do:
		[:aTab |
			tabsMorph addTab: aTab.
			aTab unHighlight.
			(itsBook _ aTab morphToInstall) ifNotNil:
					[pages add: itsBook.
					currentPage ifNil: [currentPage _ itsBook]]].
	tabsMorph position: self position + self borderWidth