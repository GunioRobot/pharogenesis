buildDisplayPatchFrom: srcString to: dstString inClass: srcClass prettyDiffs: prettyBoolean
	"Build a display patch for mapping via diffs from srcString to dstString in the given class.  If prettyBoolean is true, do the diffing for pretty-printed forms"

	^ ((srcClass notNil and: [prettyBoolean])
		ifTrue: [PrettyTextDiffBuilder
				from: srcString
				to: dstString
				inClass: srcClass]
		ifFalse: [self from: srcString to: dstString]) buildDisplayPatch