moveButtons
	"Move buttons one at a time and let the user place them over the background.  Later can move them again by turning on AuthorModeOwner in ThreePhaseButtonMorph.
	self createButtons.	"

	| rect button |
	#(erase: eyedropper: fill: paint: rect: ellipse: polygon: line: star: "pickup: pickup: pickup: pickup:" "stamp: stamp: stamp: stamp:" undo: keep: toss: prevStamp: nextStamp:) do: [:sel |
			self inform: 'Rectangle for ',sel.
			rect _ Rectangle fromUser.
			button _ self submorphNamed: sel.
			button bounds: rect.	"image is nil"].
	#(brush1: brush2: brush3: brush4: brush5: brush6: ) doWithIndex: [:sel :ind |
			self inform: 'Rectangle for ',sel.
			rect _ Rectangle fromUser.
			button _ self submorphNamed: sel.
			button bounds: rect.	"image is nil"].
	"stamp:  Stamps are held in a ScrollingToolHolder.  Pickups and stamps and brushes are id-ed by the button == with item from a list."

	"
	"
