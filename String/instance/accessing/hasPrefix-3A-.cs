hasPrefix: subString
	"Answer the remainder of the receiver if subString is the beginning of the receiver. If the receiver does not start with subString, answer nil."

	| aCharacter index |
	subString size > self size ifTrue: [^ nil].
	aCharacter _ subString first.
	index _ 1.
	[(self at: index) = (subString at: index)] whileTrue:
				[index = subString size ifTrue: [
					^ self copyFrom: index+1 to: self size].
				index _ index+1].
	^ nil 