pickupMouseUp: evt
	"Grab a part of the picture (or screen) and store it in a known place. Like Copy on the Mac menu. Then switch to the stamp tool."

	| rr pp pForm ii oldRect curs |
	lastEvent == nil ifFalse: [
			"Last draw will stick out, must erase the area"
			oldRect _ strokeOrigin rect: lastEvent cursorPoint + (14@14).
			self restoreRect: oldRect].
	self primaryHand showTemporaryCursor: nil.	"later get rid of this"	
	rr _ strokeOrigin rect: evt cursorPoint + (14@14).
	pp _ rr translateBy: self world viewBox origin.
	ii _ rr translateBy: (0@0) - bounds origin.
	(rr intersects: bounds) ifTrue: [
		pForm _ paintingForm copy: ii.
		pForm primCountBits > 0 
			ifTrue: []	"normal case.  Can be transparent in parts"
			ifFalse: [pForm _ nil.
			"Get an un-dimmed picture of other objects on the playfield"
			"don't know how yet"]].
	pForm ifNil: [pForm _ Form fromDisplay: pp].		"Anywhere on the screen"
	palette pickupForm: pForm.
	curs _ palette actionCursor.
	evt hand
		showTemporaryCursor: curs 
		hotSpotOffset: (curs ifNil: [0@0] ifNotNil: [curs offset]).
