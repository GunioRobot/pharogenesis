valueForRepeatingInterval

	| n s |

	n _ self targetProperties delayBetweenFirings.

	s _ n ifNil: [
		'*none*'
	] ifNotNil: [
		n < 1000 ifTrue: [n printString,' ms'] ifFalse: [(n // 1000) printString,' secs']
	].
	^'interval: ' translated, s
