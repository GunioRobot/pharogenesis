recalculateNewSampleLocationForStream: aStream givenFrame: aFrame
	| estimated |

	self hasAudio ifFalse: [^self].
	estimated _ (aFrame / (self videoFrames: aStream) * (self audioSampleRate: aStream)) asInteger.
	self currentAudioSampleForStream: aStream put: estimated.