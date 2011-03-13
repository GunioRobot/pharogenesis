rectForRow: index
	"return a rectangle containing the row at index"
	
	| top |
	top _ self top + (index - 1 * font height).
	^ (self left @ top) extent: self width @ font height
