encodeImage: form
	
	| t answer |

	form ifNil: [^''].
	t _ Time millisecondsToRun: [answer _ form encodeForRemoteCanvas].
	form boundingBox area > 5000 ifTrue: [
		NebraskaDebug at: #FormEncodeTimes add: {t. form extent. answer size}
	].
	^answer

	"HandMorph>>restoreSavedPatchOn: is one culprit here"

