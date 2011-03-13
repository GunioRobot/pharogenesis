buildReceiverVariablesView: aDebugger

	| receiverVariablesView leftView rightView |
	receiverVariablesView _ InspectorView inspector: aDebugger receiverInspector.
	receiverVariablesView controller: Controller new.
	leftView _ receiverVariablesView firstSubView.
	rightView _ receiverVariablesView lastSubView.
	leftView window: (0 @ 0 extent: self receiverVariablesLeftSize).
	leftView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	rightView window: (0 @ 0 extent: self receiverVariablesRightSize).
	rightView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	rightView transformation: View identityTransformation.
	rightView align: rightView viewport topLeft with: leftView viewport topRight.
	receiverVariablesView window: receiverVariablesView defaultWindow.
	^receiverVariablesView