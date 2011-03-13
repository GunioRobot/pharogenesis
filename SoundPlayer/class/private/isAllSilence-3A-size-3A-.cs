isAllSilence: buffer size: count
	"return true if the buffer is all silence after reverb has ended"
	| value |
	value _ buffer at: 1.
	2 to: count do:[:i| (buffer at: i) = value ifFalse:[^false]].
	^true