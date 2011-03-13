testMenuHandles
	| menuHandle |
	1 to: 99 do: [:i | menuHandle :=  interface getMenuHandle: i.
			menuHandle isZero ifTrue: [^self]] 
