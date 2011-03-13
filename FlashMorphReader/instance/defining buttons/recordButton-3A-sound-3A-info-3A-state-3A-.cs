recordButton: id sound: soundId info: soundInfo state: state
	"Give the button a sound"
	| button theSound |
	button := buttons at: id ifAbsent:[^self halt].
	theSound := self createSound: soundId info: soundInfo.
	theSound ifNil:[^self].
	button addSound: theSound forState: state.