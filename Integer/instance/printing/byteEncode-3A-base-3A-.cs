byteEncode: aStream base: b 
	"Print a representation of the receiver on the stream, aStream, in base, b, 
	where 2<=b<=16."
	| digits source dest i j pos t rem |

	self negative ifTrue:[aStream print:$-].
	i _ self digitLength.
	"Estimate size of result, conservatively"
	digits _ self digitBuffer:i.
	pos _ 0.
	dest _ self destinationBuffer:i.
	source _ self.
	[i >= 1]
		whileTrue: 
			[rem _ 0.
			j _ i.
			[j > 0]
				whileTrue: 
					[t _ (rem bitShift: 8) + (source digitAt: j).
					dest digitAt: j put: t // b.
					rem _ t \\ b.
					j _ j - 1].
			pos _ pos + 1.
			digits at: pos put: rem.
			source _ dest.
			(source digitAt: i) = 0 ifTrue: [i _ i - 1]].
	"(dest digitAt: 1) printOn: aStream base: b."
	[pos > 0]
		whileTrue:
			[aStream print:(Character digitValue: (digits at: pos)).
			pos _ pos - 1]