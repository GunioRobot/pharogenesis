fridgeForm

	| fridgeFileName |

	fridgeFileName _ 'fridge.form'.
	TheFridgeForm ifNotNil: [^TheFridgeForm].
	(FileDirectory default fileExists: fridgeFileName) ifFalse: [^nil].
	^TheFridgeForm _ Form fromFileNamed: fridgeFileName.