setType: evtType startPoint: evtStart endPoint: evtEnd trail: evtTrail buttons: evtButtons hand: evtHand stamp: stamp
	type _ evtType.
	startPoint _ evtStart.
	position _ evtEnd.
	trail _ evtTrail.
	buttons _ evtButtons.
	source _ evtHand.
	wasHandled _ false.
	timeStamp _ stamp.