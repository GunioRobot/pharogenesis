modalFileSelector

	| window |

	window _ self morphicViewFileSelector.
	window openCenteredInWorld.
	[window world notNil] whileTrue: [
		window outermostWorldMorph doOneCycle.
	].
	^(window valueOfProperty: #fileListModel) getSelectedFile