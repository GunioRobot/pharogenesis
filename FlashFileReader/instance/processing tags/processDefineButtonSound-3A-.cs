processDefineButtonSound: data
	| id soundID soundInfo |
	id _ data nextWord.
	#(0 mouseEnter mouseDown 3) do:[:state|
		soundID _ data nextWord.
		soundID = 0 ifFalse:[
			soundInfo _ self processSoundInfoFrom: data.
			self recordButton: id sound: soundID info: soundInfo state: state]].
	^true