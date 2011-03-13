setType: evtType position: evtPos which: button buttons: evtButtons hand: evtHand stamp: stamp
	type _ evtType.
	position _ evtPos.
	buttons _ evtButtons.
	source _ evtHand.
	wasHandled _ false.
	whichButton _ button.
	timeStamp _ stamp.