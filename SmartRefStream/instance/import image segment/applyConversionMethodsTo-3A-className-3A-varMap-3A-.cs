applyConversionMethodsTo: objectIn className: className varMap: varMap

	| anObject prevObject |

	self flag: #bobconv.	

	anObject _ objectIn.
	[
		prevObject _ anObject.
		anObject _ anObject convertToCurrentVersion: varMap refStream: self.
		prevObject == anObject
	] whileFalse.
	^anObject
