printOn: aStream base: b
	"Refer to the comment in Integer|printOn:base:."
	"SmallInteger maxVal printStringBase: 2"

	| digitsInReverse x i |
	self < 0 ifTrue: [
		aStream nextPut: $-.
		^ self negated printOn: aStream base: b.
	].

	b = 10 ifFalse: [aStream print: b; nextPut: $r].
	digitsInReverse _ Array new: 32.
	x _ self.
	i _ 0.
	[x >= b] whileTrue: [
		digitsInReverse at: (i _ i + 1) put: x \\ b.
		x _ x // b.
	].
	digitsInReverse at: (i _ i + 1) put: x.
	[i > 0] whileTrue: [
		aStream nextPut: (Character digitValue: (digitsInReverse at: i)).
		i _ i - 1.
	].