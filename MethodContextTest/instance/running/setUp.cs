setUp
	super setUp.
	aCompiledMethod _ Rectangle methodDict at: #rightCenter.
	aReceiver _ 100@100 corner: 200@200.
	aSender _ thisContext.
	aMethodContext _ MethodContext sender: aSender receiver: aReceiver method: aCompiledMethod arguments: #(). 