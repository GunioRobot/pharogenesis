openOn: anObject withEvalPane: withEval withLabel: label
	Smalltalk isMorphic ifTrue:
		[^ self openAsMorphOn: anObject withEvalPane: withEval
			withLabel: label valueViewClass: nil].
	^ self openOn: anObject 
		withEvalPane: withEval 
		withLabel: label 
		valueViewClass: PluggableTextView
