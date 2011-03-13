selectedTabBounds

 	| tsm aSelectedTab |
	tsm := self tabSelectorMorph.
	aSelectedTab := tsm selectedTab. 
	^aSelectedTab bounds.