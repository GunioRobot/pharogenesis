mouseDownEvent: evt letterMorph: morph

	haveTypedHere _ false.
	evt hand newKeyboardFocus: morph.
	self highlight: morph