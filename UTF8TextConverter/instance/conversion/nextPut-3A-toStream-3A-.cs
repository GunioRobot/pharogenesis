nextPut: aCharacter toStream: aStream 
	| leadingChar nBytes mask shift ucs2code |
	aStream isBinary ifTrue: [
		aCharacter class == Character ifTrue: [
			aStream basicNextPut: aCharacter.
			^ aStream.
		].
		aCharacter class = MultiCharacter ifTrue: [
			aStream nextInt32Put: aCharacter value.
			^ aStream.
		].
	].
	leadingChar _ aCharacter leadingChar.
	(leadingChar = 0 and: [aCharacter asciiValue < 128]) ifTrue: [
		aStream basicNextPut: aCharacter.
		^ aStream.
	].

	"leadingChar > 3 ifTrue: [^ aStream]."

	ucs2code _ aCharacter asUnicode.
	ucs2code ifNil: [^ aStream].

	nBytes _ ucs2code highBit + 3 // 5.
	mask _ #(128 192 224 240 248 252 254 255) at: nBytes.
	shift _ nBytes - 1 * -6.
	aStream basicNextPut: (Character value: (ucs2code bitShift: shift) + mask).
	2 to: nBytes do: [:i | 
		shift _ shift + 6.
		aStream basicNextPut: (Character value: ((ucs2code bitShift: shift) bitAnd: 63) + 128).
	].

	^ aStream.
