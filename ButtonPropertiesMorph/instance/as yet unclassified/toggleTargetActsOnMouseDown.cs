toggleTargetActsOnMouseDown

	| prop |

	prop _ self targetProperties.
	prop actWhen: (prop actWhen == #mouseDown ifTrue: [nil] ifFalse: [#mouseDown])