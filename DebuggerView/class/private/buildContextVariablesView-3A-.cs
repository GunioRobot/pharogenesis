buildContextVariablesView: aDebugger

	| contextVariablesView leftView rightView |
	contextVariablesView _ 
		InspectorView inspector: aDebugger contextVariablesInspector.
	contextVariablesView controller: Controller new.
	leftView _ contextVariablesView firstSubView.
	rightView _ contextVariablesView lastSubView.
	leftView window: (0 @ 0 extent: self contextVariablesLeftSize).
	leftView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	rightView window: (0 @ 0 extent: self contextVariablesRightSize).
	rightView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	rightView transformation: View identityTransformation.
	rightView align: rightView viewport topLeft with: leftView viewport topRight.
	contextVariablesView window: contextVariablesView defaultWindow.
	^contextVariablesView