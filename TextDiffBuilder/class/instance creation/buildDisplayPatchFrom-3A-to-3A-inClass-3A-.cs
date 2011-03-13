buildDisplayPatchFrom: srcString to: dstString inClass: srcClass 
	^ ((srcClass notNil and: [ (Preferences valueOfFlag: #diffsWithPrettyPrint) ])
		ifTrue: [PrettyTextDiffBuilder
				from: srcString
				to: dstString
				inClass: srcClass]
		ifFalse: [self from: srcString to: dstString]) buildDisplayPatch