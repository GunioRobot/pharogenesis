pairsDo: aBlock 
	"March through the receiver two elements at a time.  If there's an odd number of items, ignore the last one.  Allows use of a flattened array for things that naturally group into pairs.  "

	| i |
	1 to: self size // 2 do:
		[:index |
			i _ 2 * index - 1.
			 aBlock value: (self at: i) value: (self at: i + 1)]

"#(1 'fred' 2 'charlie' 3 'elmer') pairsDo:
	[:a :b | Transcript cr; show: b, ' is number ', a printString]"