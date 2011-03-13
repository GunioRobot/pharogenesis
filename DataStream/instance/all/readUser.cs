readUser
	"Reconstruct both the private class and the instance.  7/29/96 tk"
	| instSize aSymbol refPosn anObject |

	anObject _ self readInstance.		"Will create new unique class"
	^ anObject