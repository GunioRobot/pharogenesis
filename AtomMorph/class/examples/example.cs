example
	"
	AtomMorph example
	"
	|a|
	a := AtomMorph new openInWorld. 
	a color: Color random.
 	[1000 timesRepeat:  [a bounceIn: World bounds.  (Delay forMilliseconds: 50) wait]. 
	 a delete] fork.