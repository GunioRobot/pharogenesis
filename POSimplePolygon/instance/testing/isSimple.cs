isSimple
	"	| queue edges event prev next sleeve1 sleeve2 |
queue _ self asSortedCollection removeLast; yourself. 
	edges _ OrderedCollection new. 
	[queue isEmpty] 
	whileFalse:  
	[event _ queue removeFirst. 
	prev _ self before: event. 
	next _ self after: event. 
	sleeve1 _ prev x <= event x. 
	sleeve2 _ next x <= event x. 
	sleeve1 ifTrue: [edges remove: prev]. 
	sleeve2 ifTrue: [edges remove: event]. 
	sleeve1 ifFalse: [edges do: [:origin | ((origin 
	to: (self after: origin) 
	intersects: prev 
	to: event) 
	and: [prev ~= (self after: origin)]) 
	ifTrue: [^ false]]]. 
	sleeve2 ifFalse: [edges do: [:origin | ((origin 
	to: (self after: origin) 
	intersects: event 
	to: next) 
	and: [next ~= origin]) 
	ifTrue: [^ false]]]. 
	sleeve1 ifFalse: [edges add: prev]. 
	sleeve2 ifFalse: [edges add: event]]."

	^ true