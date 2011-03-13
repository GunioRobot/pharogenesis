name
	"Look to see if this Color has a name.  Must be an exact match of color. 6/19/96 tk"
	ColorNames do: [:each | 
		(Color perform: each) = self ifTrue: [
			^ each]].
	^ nil