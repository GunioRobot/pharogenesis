veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared."

super veryDeepInner: deepCopier.
"parent _ parent.		Weakly copied"
"myChangeSet _ myChangeSet.		Weakly copied"
currentClassName _ currentClassName veryDeepCopyWith: deepCopier.
"currentSelector _ currentSelector.		Symbol"
priorChangeSetList _ priorChangeSetList veryDeepCopyWith: deepCopier.
changeSetCategory _ changeSetCategory.

