additionsToViewerCategories
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #((joystick (
(slot amount 'The amount of displacement' number readOnly player getAmount unused unused)
(slot angle 'The angular displacement' number readOnly player getAngle  unused  unused)
(slot leftRight  'The horizontal displacement' number  readOnly player getLeftRight  unused  unused)
(slot upDown 'The vertical displacement' number  readOnly player getUpDown unused unused))))


