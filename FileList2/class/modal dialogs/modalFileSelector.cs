modalFileSelector

	| window |

	window _ self morphicViewFileSelector.
	window openCenteredInWorld.
	self modalLoopOn: window.
	^(window valueOfProperty: #fileListModel) getSelectedFile