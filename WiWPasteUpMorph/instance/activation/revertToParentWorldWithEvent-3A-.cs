revertToParentWorldWithEvent: evt

	"RAA 27 Nov 99 - if the display changed while we were in charge, parent may need to redraw"

	self damageRecorder reset.	"Terminate local display"
	World _ parentWorld.
	World assuredCanvas.
	World installFlaps.
	hostWindow setStripeColorsFrom: Color red.
	(displayChangeSignatureOnEntry = Display displayChangeSignature) ifFalse: [
		World fullRepaintNeeded; displayWorld
	].
	evt ifNotNil: [World restartWorldCycleWithEvent: evt].

