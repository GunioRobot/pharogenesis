prototypeAt: aNodeSpec
	^self prototypes at: aNodeSpec ifAbsent:[Array with:VRMLUndefinedNode new].