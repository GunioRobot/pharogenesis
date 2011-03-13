printArgumentsOn: aStream indent: level
	arguments size = 0
		ifTrue: [^ self].
	aStream dialect = #SQ00
		ifTrue: [aStream
				withStyleFor: #setOrReturn
				do: [aStream nextPutAll: 'With'].
			arguments
				do: [:arg | 
					aStream space.
					aStream
						withStyleFor: #blockArgument
						do: [aStream nextPutAll: arg key]].
			aStream nextPutAll: '. ']
		ifFalse: [arguments
				do: [:arg | aStream
						withStyleFor: #blockArgument
						do: [aStream nextPutAll: ':';
								 nextPutAll: arg key;
								 space]].
			aStream nextPutAll: '| '].
	"If >0 args and >1 statement, put all statements on separate lines"
	statements size > 1
		ifTrue: [aStream crtab: level]