createWindow
	"Create the package loader window."
	
	self addMorph: (self buildSearchPane borderWidth: 0)
		frame: (0.0 @ 0.0 corner: 0.3 @ 0.07).
	self addMorph: (self buildMorphicPackagesList borderWidth: 0)
		frame: (0.0 @ 0.07 corner: 0.3 @ 0.6).
	self addMorph: (self buildMorphicCategoriesList borderWidth: 0)
		frame: (0.0 @ 0.6 corner: 0.3 @ 1.0).
	self addMorph: (self buildPackagePane borderWidth: 0)
		frame: (0.3 @ 0.0 corner: 1.0 @ 1.0).
	self on: #mouseEnter send: #paneTransition: to: self.
	self on: #mouseLeave send: #paneTransition: to: self