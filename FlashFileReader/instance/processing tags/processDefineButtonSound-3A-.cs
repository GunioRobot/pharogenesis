processDefineButtonSound: data
	| id soundID soundInfo |
	id := data nextWord.
	#(0 mouseEnter mouseDown 3) do:[:state|
		soundID := data nextWord.
		soundID = 0 ifFalse:[
			soundInfo := self processSoundInfoFrom: data.
			self recordButton: id sound: soundID info: soundInfo state: state]].
	^true