recordButton: buttonId actions: actionList condition: condition
	"Associate an action list with the given button:
		buttonId:	global ID of the button
		actions:		Collection of MessageSends (e.g., actions)
		condition:	bit mask describing when the actions should be applied
					General conditions:
						1 - IdleToOverUp (Mouse enter up)
						2 - OverUpToIdle (Mouse exit up)
						4 - OverUpToOverDown (Mouse down)
						8 - OverDownToOverUp (Mouse up in)
					Push button conditions:
						16 - OverDownToOutDown (Mouse exit down)
						32 - OutDownToOverDown (Mouse enter down)
						64 - OutDownToIdle (Mouse up out)
					Menu button conditions:
						128 - IdleToOverDown (Mouse enter down)
						256 - OverDownToIdle (Mouse exit down)"
