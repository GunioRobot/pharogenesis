graphicForViewerTab
	"When a Viewer is open on the receiver, its tab needs some graphic to show to the user.  Answer a form or a morph to serve that purpose.  A generic image is used for arbitrary objects, but note my reimplementors"
	| aCamera image thumb |
	aCamera _ WonderlandStillCamera createFor: myWonderland.
	aCamera turnBackgroundOff.
	aCamera setFocusObject: self.
	thumb _ aCamera getMorph imageForm.
	aCamera getMorph delete.
	aCamera removeFromScene. "silently"
	thumb _ thumb trimBordersOfColor: Color transparent.
	image _ Form extent: (thumb extent x max: thumb extent y) asPoint depth: thumb depth.
	image fillColor: myWonderland getScene getColorObject asColor.
	thumb displayOn: image at: (image extent - thumb extent // 2) rule: Form paint.
	^image