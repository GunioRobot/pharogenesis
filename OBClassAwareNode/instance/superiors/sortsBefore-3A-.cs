sortsBefore: aClassNode
	| own other |
	own := self withSuperiors.
	other := aClassNode withSuperiors.
	1 	to: (own size min: other size)
		do: [:i | (own at: i) == (other at: i) ifFalse: 
				[^ (own at: i) theClassName <= (other at: i) theClassName]].
	^ other includes: self
	