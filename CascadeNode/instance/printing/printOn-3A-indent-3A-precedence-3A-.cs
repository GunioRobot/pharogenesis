printOn: aStream indent: level precedence: p
	| thisPrec |
	p > 0 ifTrue: [aStream nextPut: $(].
	thisPrec _ messages first precedence.
	receiver printOn: aStream indent: level precedence: thisPrec.
	1 to: messages size do: 
		[:i | 
		(messages at: i) printOn: aStream indent: level.
		i < messages size
			ifTrue: [aStream nextPut: $;.
					thisPrec >= 2 ifTrue: [aStream crtab: level]]].
	p > 0 ifTrue: [aStream nextPut: $)]