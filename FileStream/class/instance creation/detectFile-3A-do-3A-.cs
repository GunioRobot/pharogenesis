detectFile: aBlock do: anotherBlock
	
	| file |

	file := aBlock value.
	^ file 
		ifNil: [ nil ]
         ifNotNil: [ [anotherBlock value: file] ensure: [file close]]