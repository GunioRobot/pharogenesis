pickupMouseUp: evt
	"Grab a part of the picture (or screen) and store it in a known place. Like Copy on the Mac menu. Then switch to the stamp tool."

	| rr pForm ii oldRect sOrigin priorEvt |

	sOrigin _ self get: #strokeOrigin for: evt.
	(priorEvt _ self get: #lastEvent for: evt) == nil ifFalse: [
			"Last draw will stick out, must erase the area"
			oldRect _ sOrigin rect: priorEvt cursorPoint + (14@14).
			self restoreRect: (oldRect insetBy: -2)].
	self primaryHand showTemporaryCursor: nil.	"later get rid of this"	
	rr _ sOrigin rect: evt cursorPoint + (14@14).
	ii _ rr translateBy: (0@0) - bounds origin.
	(rr intersects: bounds) ifTrue: [
		pForm _ paintingForm copy: ii.
		pForm isAllWhite "means transparent" 
			ifFalse: []	"normal case.  Can be transparent in parts"
			ifTrue: [pForm _ nil.
			"Get an un-dimmed picture of other objects on the playfield"
			"don't know how yet"]].
	pForm ifNil: [pForm _ Form fromDisplay: rr].		"Anywhere on the screen"
	palette pickupForm: pForm evt: evt.
	evt hand showTemporaryCursor: (self getCursorFor: evt).
