howManyMatch: string 
	"Count the number of characters that match up in self and aString."
	| count shorterLength |
	
	count  _  0 .
	shorterLength  _  ((self size ) min: (string size ) ) .
	(1 to: shorterLength  do: [:index |
		 (((self at: index ) = (string at: index )  ) ifTrue: [count  _  (count + 1 ) .
			]   ).
		]   ).
	^  count 
	
	