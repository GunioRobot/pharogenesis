veryDeepInner: deepCopier
	super veryDeepInner: deepCopier.
	items _ items veryDeepCopyWith: deepCopier.
	border _ border veryDeepCopyWith: deepCopier