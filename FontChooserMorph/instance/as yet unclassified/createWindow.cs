createWindow
	"Create the package loader window."
	| buttonBarHeight b |

	buttonBarHeight := Preferences standardDefaultTextFont height + 22.
	self addMorph: (self newFontList borderWidth: 0)
		frame: (0.0 @ 0.0 corner: 0.5 @ 0.4) .
	self addMorph: ((styleList := self newFontStyleList) borderWidth: 0)
		frame: (0.5 @ 0.0 corner: 0.9 @ 0.4).
	self addMorph: (pointSizeList := self newPointSizeList borderWidth:0)
		frame: (0.9 @ 0.0 corner: 1.0 @ 0.4).
	self addMorph: (self fontPreviewPanel borderWidth: 0)
		fullFrame: (LayoutFrame fractions: (0@0.4 corner: 1.0@1.0) offsets: (0@0 corner: 0@buttonBarHeight negated)). 

	self addMorph: (applyButton:=self applyButton)
		fullFrame: (LayoutFrame fractions: (0@1.0 corner: 0.25@1.0) offsets: (10@(buttonBarHeight negated + 2) corner: -10@-4)).
	applyButton color: self paneColor darker.

	self addMorph: (okButton :=self okButton) 
		fullFrame: (LayoutFrame fractions: (0.25@1.0 corner: 0.50@1.0) offsets: (10@(buttonBarHeight negated + 2)  corner: -10@-4)).
	okButton color: self paneColor darker.

	self addMorph: (cancelButton :=self cancelButton) 
		fullFrame: (LayoutFrame fractions: (0.50@1.0 corner: 0.75@1.0) offsets: (10@(buttonBarHeight negated + 2) corner: -10@-4)).
	cancelButton color: self paneColor darker.

	self addMorph: (updateButton:=self updateButton)
		fullFrame: (LayoutFrame fractions: (0.75@1.0 corner: 1.0@1.0) offsets: (10@(buttonBarHeight negated + 2) corner: -10@-4)).
	updateButton color: self paneColor darker.

	self addMorph: (b :=Morph new)
		fullFrame: (LayoutFrame fractions: (0@1.0 corner: 1.0@1.0) offsets: (4@buttonBarHeight negated  - 4 corner: 0@0)).


	b color: self paneColor lighter.
	updateButton comeToFront.
"	applyButton comeToFront."
	okButton comeToFront.
	cancelButton comeToFront.
	self on: #mouseEnter send: #paneTransition: to: self.
	self on: #mouseLeave send: #paneTransition: to: self