generateMouseEvent: evtBuf
	"Generate the appropriate mouse event for the given raw event buffer"
	| position buttons modifiers type trail stamp oldButtons |
	stamp _ (evtBuf at: 2).
	stamp = 0 ifTrue:[stamp _ Time millisecondClockValue].
	position _ (evtBuf at: 3) @ (evtBuf at: 4).
	buttons _ (evtBuf at: 5).
	modifiers _ (evtBuf at: 6).
	buttons = 0 
		ifTrue:[	(lastEventBuffer at: 5) = 0
					ifTrue:[type _ #mouseMove]
					ifFalse:[type _ #mouseUp]]
		ifFalse:[	(lastEventBuffer at: 5) = 0
					ifTrue:[type _ #mouseDown]
					ifFalse:[type _ #mouseMove]].
	buttons _ buttons bitOr: (modifiers bitShift: 3).
	oldButtons _ (lastEventBuffer at: 5) bitOr: ((lastEventBuffer at: 6) bitShift: 3).
	lastEventBuffer _ evtBuf.
	type == #mouseMove ifTrue:[
		trail _ self mouseTrailFrom: evtBuf.
		^MouseMoveEvent new 
			setType: type 
			startPoint: trail first
			endPoint: trail last 
			trail: trail
			buttons: buttons
			hand: self
			stamp: stamp.
	].
	^MouseButtonEvent new 
		setType: type 
		position: position
		which: (oldButtons bitXor: buttons)
		buttons: buttons 
		hand: self
		stamp: stamp