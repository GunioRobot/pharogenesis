printTemporariesOn: aStream indent: level

	(temporaries == nil or: [temporaries size = 0])
		ifFalse: 
			[aStream nextPut: $|.
			temporaries do: 
				[:arg | 
				aStream
					space;
					withStyleFor: #temporaryVariable
						do: [aStream nextPutAll: arg key]].
			aStream nextPutAll: ' | '.
			"If >0 args and >1 statement, put all statements on separate lines"
			statements size > 1 ifTrue: [aStream crtab: level]]