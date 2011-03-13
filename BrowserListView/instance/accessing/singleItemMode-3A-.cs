singleItemMode: aBoolean 
	"The argument indicates whether the list contains one element. If it does, 
	select it."

	singleItemMode _ aBoolean.
	singleItemMode ifTrue: [selection _ 1]