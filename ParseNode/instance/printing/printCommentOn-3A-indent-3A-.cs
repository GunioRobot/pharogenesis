printCommentOn: aStream indent: indent 
	| thisComment |
	comment == nil ifTrue: [^ self].
	aStream withStyleFor: #comment
		do: [1 to: comment size do: 
				[:index | 
				index > 1 ifTrue: [aStream crtab: indent].
				aStream nextPut: $".
				thisComment _ comment at: index.
				self printSingleComment: thisComment
					on: aStream
					indent: indent.
				aStream nextPut: $"]].
	comment _ nil