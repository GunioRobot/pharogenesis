noVeneer
	"For a palette with a background (off) image, clear that image.
But first, for each button, cut that chunk out and save it in the offImage
part."
	"	self noVeneer.
		AllOffImage := nil.	'save space.  irreversible'.	"

	| aa on |
	AllOffImage ifNil: [AllOffImage := image].
	aa := AllOffImage.
	"Collect all the images for the buttons in the on state"
	self allMorphsDo: [:button |
		(button isKindOf: ThreePhaseButtonMorph) ifTrue: [
			on := Form extent: button extent depth: 16.
			on copy: (0@0 extent: button extent)
				from: (button topLeft - self topLeft) in:
aa rule: Form over.
			button offImage: on]].
	self image: (Form extent: AllOffImage extent depth: 1).
	self invalidRect: bounds.


	