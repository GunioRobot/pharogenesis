veryDeepFixupWith: deepCopier
	"If target and arguments fields were weakly copied, fix them here.  If they were in the tree being copied, fix them up, otherwise point to the originals!!"

super veryDeepFixupWith: deepCopier.
target _ deepCopier references at: target ifAbsent: [target].
arguments _ arguments collect: [:each |
	deepCopier references at: each ifAbsent: [each]].
getItemsArgs _ getItemsArgs collect: [:each |
	deepCopier references at: each ifAbsent: [each]].
choiceArgs ifNotNil: [choiceArgs _ choiceArgs collect: [:each |
	deepCopier references at: each ifAbsent: [each]]].