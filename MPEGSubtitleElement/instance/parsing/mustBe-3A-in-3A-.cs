mustBe: text in: aStream
	" Check text to be present in aStream. "

	(text isKindOf: Character) ifTrue: [
		^self is: (String with: text) in: aStream
	].
	(self is: text in: aStream) ifFalse: [
		^self error: 'Invalid token, must be: ',text
	].