asGregorian
	"Return an array of integers #(dd mm yyyy)"

	| l n i j dd mm yyyy |

	l _ self julianDayNumber + 68569.
	n _ (4 * l) // 146097.
	l _ l - ( (146097 * n + 3) // 4 ).
	i _ (4000 * (l + 1) ) // 1461001.
	l _ l - ( (1461 * i) // 4 ) + 31.
	j _ (80 *l) // 2447.
	dd _ l - ( (2447 * j) // 80 ).
	l _ j // 11.
	mm _ j + 2 - (12 * l).
	yyyy _ 100 * (n -49) + i + l.

	^Array with: dd with: mm with: yyyy.