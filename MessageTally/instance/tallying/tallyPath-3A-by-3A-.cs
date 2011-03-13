tallyPath: context by: count
	| aMethod path |
	aMethod _ context method.
	receivers do: 
		[:aMessageTally | 
		aMessageTally method == aMethod ifTrue: [path _ aMessageTally]].
	path == nil ifTrue: 
		[path _ MessageTally new class: context receiver class method: aMethod;
			maxClassNameSize: maxClassNameSize;
			maxClassPlusSelectorSize: maxClassPlusSelectorSize;
			maxTabs: maxTabs.
		receivers _ receivers copyWith: path].
	^ path bumpBy: count