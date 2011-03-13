modalFileSelector

	| window |

	window := self morphicViewFileSelector.
	window openCenteredInWorld.
	self modalLoopOn: window.
	^(window valueOfProperty: #fileListModel) getSelectedFile