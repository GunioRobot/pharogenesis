createButtons
	"Create buttons one at a time and let the user place them over the background.  Later can move them again by turning on AuthorModeOwner in ThreePhaseButtonMorph.
	self createButtons.	"

	| rect button nib |
	#(erase: eyedropper: fill: paint: rect: ellipse: polygon: line: star: pickup: "pickup: pickup: pickup:" stamp: "stamp: stamp: stamp:" undo: keep: toss: prevStamp: nextStamp:) do: [:sel |
		(self submorphNamed: sel) ifNil:
			[self inform: 'Rectangle for ',sel.
			rect _ Rectangle fromUser.
			button _ ThreePhaseButtonMorph new.
			button onImage: nil; bounds: rect.
			self addMorph: button.
			button actionSelector: #tool:action:cursor:evt:; arguments: (Array with: button with: sel with: nil).
			button actWhen: #buttonUp; target: self]].
	#(brush1: brush2: brush3: brush4: brush5: brush6: ) doWithIndex: [:sel :ind |
		(self submorphNamed: sel) ifNil:
			[self inform: 'Rectangle for ',sel.
			rect _ Rectangle fromUser.
			button _ ThreePhaseButtonMorph new.
			button onImage: nil; bounds: rect.
			self addMorph: button.
			nib _ Form dotOfSize: (#(1 2 3 6 11 26) at: ind).
			button actionSelector: #brush:action:nib:evt:; 
					arguments: (Array with: button with: sel with: nib).
			button actWhen: #buttonUp; target: self]].
	"stamp:  Stamps are held in a ScrollingToolHolder.  Pickups and stamps and brushes are id-ed by the button == with item from a list."


