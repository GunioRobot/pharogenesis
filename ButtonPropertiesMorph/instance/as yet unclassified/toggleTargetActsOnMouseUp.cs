toggleTargetActsOnMouseUp

	| prop |

	prop _ self targetProperties.
	prop actWhen: (prop actWhen == #mouseUp ifTrue: [nil] ifFalse: [#mouseUp])