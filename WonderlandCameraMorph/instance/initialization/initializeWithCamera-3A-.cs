initializeWithCamera: aCamera
	"Initialize this instance and hand it a camera"

	myCamera _ aCamera.
	myWonderland _ aCamera getWonderland.
	self name: (myCamera getName).

	"Use a transparent background"
	color _ (Color transparent).

	self bounds: (20@20 corner: 170@170)