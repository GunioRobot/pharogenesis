scanNumber
	| start c nc |
	start := sourcePosition.
	self skipDigits.
	c := self currentChar.
	c = $r 
		ifTrue: [
			self skipBigDigits.
			currentToken := source copyFrom: start to: sourcePosition - 1.
			^currentTokenSourcePosition := start].
	c = $s 
		ifTrue: [
			self skipDigits.
			currentToken := source copyFrom: start to: sourcePosition - 1.
			^currentTokenSourcePosition := start].
	c = $. 
		ifTrue: [
			self nextChar isDigit 
				ifFalse: [
					sourcePosition := sourcePosition - 1.
					currentToken := source copyFrom: start to: sourcePosition - 1.
					^currentTokenSourcePosition := start]
				ifTrue: [self skipDigits.].
			c := self currentChar.
			(#($d $e $q) includes: c) 
				ifTrue: [
					((nc := self nextChar) isDigit or: [nc = $-]) 
						ifTrue: [
							self skipDigits.
							currentToken := source copyFrom: start to: sourcePosition - 1.
							^currentTokenSourcePosition := start]].
			c = $s ifTrue: [self skipDigits]].
	currentToken := source copyFrom: start to: sourcePosition - 1.
	^currentTokenSourcePosition := start