unusedLabelForInliningInto: targetMethod

	| usedLabels |
	usedLabels _ labels asSet.
	usedLabels addAll: targetMethod labels.
	^self unusedNamePrefixedBy: 'l' avoiding: usedLabels