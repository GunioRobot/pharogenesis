printCommentOn: aStream indent: indent 
	| thisComment |
	self comment == nil ifTrue: [^ self].
	aStream withStyleFor: #comment
		do: [1 to: self comment size do: 
				[:index | 
				index > 1 ifTrue: [aStream crtab: indent].
				aStream nextPut: $".
				thisComment _ self comment at: index.
				self printSingleComment: thisComment
					on: aStream
					indent: indent.
				aStream nextPut: $"]].
	self comment: nil