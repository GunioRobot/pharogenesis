clearAfter: aColumn 
	| start |
	start _ (columns indexOf: aColumn) + 1.
	start to: columns size do: [:i | (columns at: i) clear]