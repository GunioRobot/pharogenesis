dimTheWindow
	"Do not call twice!  Installs a morph with the background behind
me.  6/12/97 12:29 tk"

	| dim map notTrans fwdButton pt toggle |
	"create a dim version of the stuff on the screen"
	"dim _ Form fromDisplay: canvasRectangle."
	dim _ owner imageFormForRectangle: self bounds.
	dim fill: dim boundingBox
		rule: (dim depth < 16 ifTrue: [Form and] ifFalse: [Form under])
		fillColor: (Color pixelScreenForDepth: dim depth).
	map _ (Color cachedColormapFrom: dim depth to: dim depth) copy.
	map _ map collect: [:c |
		c = 0 ifTrue: [Color white pixelValueForDepth: dim depth]
ifFalse: [c]].
	notTrans _ BitBlt toForm: dim.
	notTrans colorMap: map; sourceForm: dim; combinationRule: Form over;
		destRect: dim boundingBox; sourceOrigin: 0@0; copyBits.

	dimForm _ SketchMorph new form: dim.
	dimForm position: self position.
	owner privateAddMorph: dimForm atIndex: (owner submorphs indexOf:
self)+1.

	"Rotation and scaling handles"
	rotationButton _ SketchMorph new form: (palette rotationTabForm).
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

	scaleButton _ SketchMorph new form: (palette scaleTabForm).
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
	self forward: hostView forwardDirection direction: fwdButton.
	"Set to its current value"

