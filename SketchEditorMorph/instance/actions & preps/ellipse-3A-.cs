ellipse: evt
	"Draw an ellipse from the center. "

	| rect oldRect ww ext oldExt |
	ext _ (strokeOrigin - evt cursorPoint) abs * 2.
	evt shiftPressed ifTrue: [ext _ ext r].
	rect _ Rectangle center: strokeOrigin extent: ext.
	ww _ palette getNib width.
	lastEvent ifNotNil: [
		oldExt _ (strokeOrigin - lastEvent cursorPoint) abs + ww * 2.
		lastEvent shiftPressed ifTrue: [oldExt _ oldExt r].
		(oldExt < ext) ifFalse: ["Last draw sticks out, must erase the area"
			oldRect _ Rectangle center: strokeOrigin extent: oldExt.
			self restoreRect: oldRect]].
	currentColor == Color transparent
	ifFalse:[
	formCanvas fillOval: rect color: currentColor 
		borderWidth: 0 borderColor: Color transparent.]
	ifTrue:[
	formCanvas fillOval: rect color: currentColor 
		borderWidth: ww borderColor: Color black].
	self invalidRect: rect.

