printWithClosureAnalysisArgumentsOn: aStream indent: level
	arguments size = 0 ifTrue: [^self].
	arguments do:
		[:tempNode |
		 aStream space; nextPut: $:.
		 tempNode printDefinitionForClosureAnalysisOn: aStream].
	aStream nextPut: $|; space.
	"If >0 args and >1 statement, put all statements on separate lines"
	statements size > 1 ifTrue:
		[aStream crtab: level]