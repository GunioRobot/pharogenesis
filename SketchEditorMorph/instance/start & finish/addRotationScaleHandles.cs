addRotationScaleHandles

	"Rotation and scaling handles"
	| fwdButton pt toggle |
	rotationButton _ SketchMorph withForm: (palette rotationTabForm).
	rotationButton position: bounds topCenter - (6@0).
	rotationButton on: #mouseDown send: #rotateScalePrep to: self.
	rotationButton on: #mouseStillDown send: #rotateBy: to: self.
	rotationButton on: #mouseUp send: #rotateDone: to: self.
	rotationButton on: #mouseEnter send: #mouseLeave: to: self.
	"Put cursor back"
	rotationButton on: #mouseLeave send: #mouseEnter: to: self.
	self addMorph: rotationButton.
	rotationButton setBalloonText: 'Drag me sideways to\rotate your
picture.' withCRs.

	scaleButton _ SketchMorph withForm: (palette scaleTabForm).
	scaleButton position: bounds rightCenter - ((scaleButton width)@6).
	scaleButton on: #mouseDown send: #rotateScalePrep to: self.
	scaleButton on: #mouseStillDown send: #scaleBy: to: self.
	scaleButton on: #mouseEnter send: #mouseLeave: to: self.
	"Put cursor back"
	scaleButton on: #mouseLeave send: #mouseEnter: to: self.
	self addMorph: scaleButton.
	scaleButton setBalloonText: 'Drag me up and down to change\the size
of your picture.' withCRs.

	fwdButton _ PolygonMorph new.
	pt _ "rotationButton topRight" bounds topCenter.
	fwdButton borderWidth: 2; makeOpen; makeBackArrow; borderColor:
(Color r: 0 g: 0.8 b: 0).
	fwdButton removeHandles; setVertices: (Array with: pt+(0@7) with:
pt+(0@22)).
	fwdButton on: #mouseStillDown send: #forward:direction: to: self.
	fwdButton on: #mouseEnter send: #mouseLeave: to: self.	"Put cursor
back"
	fwdButton on: #mouseLeave send: #mouseEnter: to: self.
	self setProperty: #fwdButton toValue: fwdButton.
	self addMorph: fwdButton.
	fwdButton setBalloonText: 'Drag me around to point\in the direction
I go forward.' withCRs.

	toggle _ EllipseMorph
		newBounds: (Rectangle center: fwdButton vertices last +
(-4@4) extent: 8@8)
		color: Color gray.
	toggle on: #mouseUp send: #toggleDirType:in: to: self.
	toggle on: #mouseEnter send: #mouseLeave: to: self.	"Put cursor
back"
	toggle on: #mouseLeave send: #mouseEnter: to: self.
	self setProperty: #fwdToggle toValue: toggle.
	fwdButton addMorph: toggle.
	toggle setBalloonText: 'When your object turns,\how should its
picture change?\It can rotate, face left or right,\face up or down, or not
change.' withCRs.
	self setProperty: #rotationStyle toValue: hostView rotationStyle.
	self forward: hostView setupAngle direction: fwdButton.
	"Set to its current value"

