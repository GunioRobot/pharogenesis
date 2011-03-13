adjustVolumeTo: vol overMSecs: mSecs
	"Adjust the volume of this sound to the given volume, a number in the range [0.0..1.0], over the given number of milliseconds. The volume will be changed a little bit on each sample until the desired volume is reached."

	| newScaledVol |

	self flag: #bob.		"I removed the upper limit to allow making sounds louder. hmm..."

	newScaledVol _ (32768.0 * vol) truncated.
	newScaledVol = scaledVol ifTrue: [^ self].
	scaledVolLimit _ newScaledVol.
	"scaledVolLimit > ScaleFactor ifTrue: [scaledVolLimit _ ScaleFactor]."
	scaledVolLimit < 0 ifTrue: [scaledVolLimit _ 0].
	mSecs = 0
		ifTrue: [  "change immediately"
			scaledVol _ scaledVolLimit.
			scaledVolIncr _ 0]
		ifFalse: [
			scaledVolIncr _
				((scaledVolLimit - scaledVol) * 1000) // (self samplingRate * mSecs)].
