printOn: s 
	"For testing only"

	1 to: board size
		do: 
			[:row | 
			s
				cr;
				next: row put: $ .
			(board at: row) do: 
					[:cell | 
					s
						space;
						nextPut: (cell isNil ifTrue: [$-] ifFalse: [cell printString last])]]