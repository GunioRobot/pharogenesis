ellipse: evt
	"Draw an ellipse from the center. "

	| rect oldRect ww ext oldExt cColor sOrigin priorEvt |

	sOrigin _ self get: #strokeOrigin for: evt.
	cColor _ self getColorFor: evt.
	ext _ (sOrigin - evt cursorPoint) abs * 2.
	evt shiftPressed ifTrue: [ext _ ext r].
	rect _ Rectangle center: sOrigin extent: ext.
	ww _ (self getNibFor: evt) width.
	(priorEvt _ self get: #lastEvent for: evt) ifNotNil: [
		oldExt _ (sOrigin - priorEvt cursorPoint) abs + ww * 2.
		priorEvt shiftPressed ifTrue: [oldExt _ oldExt r].
		(oldExt < ext) ifFalse: ["Last draw sticks out, must erase the area"
			oldRect _ Rectangle center: sOrigin extent: oldExt.
			self restoreRect: oldRect]].
	cColor == Color transparent
	ifFalse:[
	formCanvas fillOval: rect color: cColor 
		borderWidth: 0 borderColor: Color transparent.]
	ifTrue:[
	formCanvas fillOval: rect color: cColor 
		borderWidth: ww borderColor: Color black].
	self invalidRect: rect.

